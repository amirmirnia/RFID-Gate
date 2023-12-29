
using System;
using System.Collections.Generic;
using System.Linq;
using CardLib;

namespace CardReader
{
    internal class CardManagerLib
    {
        public short authenTypeA = 0x60;
        public short authenTypeB = 0x61;
        public byte[] DLL_version = new byte[33];
        public byte[] portN = new byte[4];
        public byte[] Dver = new byte[33];
        //public byte Daddress;
        public byte[] Dsn = new byte[8];
        public byte[] cardT = new byte[3];
        public byte[] cardSN = new byte[4];
        public byte[] Ckey = new byte[6];
        public byte[] databuffer = new byte[17];
        public byte[] value = new byte[4];
        public byte[] Dbuffer = new byte[64];
        private long KeyA;
        private long KeyB;

        internal bool ReadCardInfo(out long readedID, out long readedNationalID, out int readedCardSerial)
        {
            throw new NotImplementedException();
        }



        //public bool ReactiveLostCard()
        //{
        //    var card = GetLostCard(member.ID);
        //    if (card != null)
        //    {
        //        if (GetActiveCard(member.ID) != null)
        //            return false;
        //        card.Status = ModelLib.CardStatus.Active;
        //        dbc.Store(card);
        //        member.Tag = card.ID;
        //        dbc.Store(member);
        //        dbc.Commit();
        //        return true;
        //    }
        //    return false;
        //}
        internal bool ResetCard()
        {
            byte[] KeyA, KeyB, TailBlock;
            byte[] KeyA2, KeyB2, TailBlock2;
            int cserial = BitConverter.ToInt32(cardSN, 0);

            generateKeys(cserial, out KeyA, out KeyB, out TailBlock);
            generateKeys2(cserial, out KeyA2, out KeyB2, out TailBlock2);

            byte[] Data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            TailBlock = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x07, 0x80, 0x69, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };


            if (MifareAPI.MF_LoadKey(0, ref KeyB[0]) == 0)
            {
                int block = 0;
                if (MifareAPI.MF_Authentication(0, authenTypeB, 3, ref cardSN[0]) == 0)
                {
                    if (MifareAPI.MF_Write(0, 1, 1, ref Data[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 2, 1, ref Data[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 3, 1, ref TailBlock[0]) == 0)
                        block++;
                }
                if (MifareAPI.MF_LoadKey(0, ref KeyB2[0]) == 0)
                {
                    for (short Sector = 1; Sector < 16; Sector++)
                    {
                        short Authblocknumber = (short)(((Sector + 1) * 4) - 1);

                        if (MifareAPI.MF_Authentication(0, authenTypeB, Authblocknumber, ref cardSN[0]) == 0)
                        {
                            if (MifareAPI.MF_Write(0, Authblocknumber, 1, ref TailBlock[0]) == 0)
                                block++;
                        }
                    }
                }
                if (block == 18)
                    return true;
            }
            return false;
        }
        public bool ReadCardInfo(out long ID, out long NationalID)
        {

            ID = NationalID = -1;
            byte[] KeyA, KeyB, TailBlock;
            int cserial = BitConverter.ToInt32(cardSN, 0);
            generateKeys(cserial, out KeyA, out KeyB, out TailBlock);

            byte[] dataBlock = new byte[16];
            if (MifareAPI.MF_LoadKey(0, ref KeyA[0]) == 0)
            {
                short block = 3; //reading block 1 for user data
                if (MifareAPI.MF_Authentication(0, authenTypeA, block, ref cardSN[0]) == 0)
                    if (MifareAPI.MF_Read(0, 1, 1, ref dataBlock[0]) == 0)
                    {
                        byte[] idbyte = { dataBlock[0], dataBlock[1], dataBlock[2], dataBlock[3], dataBlock[4], dataBlock[5], dataBlock[6], dataBlock[7] };
                        byte[] nidbyte = { dataBlock[8], dataBlock[9], dataBlock[10], dataBlock[11], dataBlock[12], dataBlock[13], dataBlock[14], dataBlock[15] };
                        ID = BitConverter.ToInt64(idbyte, 0);
                        NationalID = BitConverter.ToInt64(nidbyte, 0);
                        return true;
                    }
            }
            return false;
        }
        public bool ReadRawCardInfo(out long ID, out long NationalID)
        {
            ID = NationalID = -1;
            byte[] KeyA = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

            byte[] dataBlock = new byte[64];
            if (MifareAPI.MF_LoadKey(0, ref KeyA[0]) == 0)
            {
                //short block = 1; //reading block 1 for user data
                if (MifareAPI.MF_Authentication(0, authenTypeA, 3, ref cardSN[0]) == 0)
                    if (MifareAPI.MF_Read(0, 0, 4, ref dataBlock[0]) == 0)
                    {
                        ID = BitConverter.ToInt64(dataBlock, 0);
                        NationalID = BitConverter.ToInt64(dataBlock, 8);
                        return true;
                    }
            }
            return false;
        }
        public void generateKeys(int CardSerialnumber, out byte[] KeyA, out byte[] KeyB, out byte[] TailBlock)
        {
            ///tak karte aval be shekl zir kod shode
            //    ///             TailBlock.Add(fourbyteArray[3]);
            //    TailBlock.AddRange(new byte[6]
            //            { fourbyteArray[2], fourbyteArray[3] ,
            //              fourbyteArray[3], fourbyteArray[2], fourbyteArray[1], fourbyteArray[0]
            //});

            int xorMate = 0xf85ec7b ^ CardSerialnumber;
            byte[] fourbyteArray = BitConverter.GetBytes(xorMate);
            KeyA = new byte[6]{ fourbyteArray[2], fourbyteArray[3],
                                            fourbyteArray[3], fourbyteArray[2],
                                            fourbyteArray[1], fourbyteArray[0]
                                            };

            byte[] Accessarea = new byte[] { 0x78, 0x77, 0x88, 0x01 };
            KeyB = new byte[] { 0xd5, 0x48, 0x39, 0xfa, 0xe7, 0xc2 };
            List<byte> tail = new List<byte>();
            tail.AddRange(KeyA);
            tail.InsertRange(6, Accessarea);
            tail.InsertRange(10, KeyB);

            TailBlock = tail.ToArray();
        }
        public void generateKeys2(int CardSerialnumber, out byte[] KeyA, out byte[] KeyB, out byte[] TailBlock)
        {
            ///tak karte aval be shekl zir kod shode
            //    ///             TailBlock.Add(fourbyteArray[3]);
            //    TailBlock.AddRange(new byte[6]
            //            { fourbyteArray[2], fourbyteArray[3] ,
            //              fourbyteArray[3], fourbyteArray[2], fourbyteArray[1], fourbyteArray[0]
            //});

            int xorMate = 0xc5086fa ^ CardSerialnumber;
            byte[] fourbyteArray = BitConverter.GetBytes(xorMate);
            KeyA = new byte[6]{ fourbyteArray[3], fourbyteArray[1],
                                            fourbyteArray[2], fourbyteArray[3],
                                            fourbyteArray[0], fourbyteArray[1]
                                            };

            byte[] Accessarea = new byte[] { 0x78, 0x77, 0x88, 0x01 };
            KeyB = new byte[] { 0xbc, 0x46, 0xfd, 0x84, 0x38, 0xbd };
            List<byte> tail = new List<byte>();
            tail.AddRange(KeyA);
            tail.InsertRange(6, Accessarea);
            tail.InsertRange(10, KeyB);

            TailBlock = tail.ToArray();
        }
        public bool ActivateRawCard(out byte[] SectorZero, long id)
        {
            SectorZero = new byte[16];
            Ckey[0] = 0xff;
            Ckey[1] = 0xff;
            Ckey[2] = 0xff;
            Ckey[3] = 0xff;
            Ckey[4] = 0xff;
            Ckey[5] = 0xff;
            if (MifareAPI.MF_LoadKey(0, ref Ckey[0]) == 0)
            {
                // if (MifareAPI.MF_Authentication(0, authenType, 3, ref cardSN[0]) == 0)
                // {


                var idbytes = BitConverter.GetBytes(0);
                var natioanlIdbytes = BitConverter.GetBytes(id);
                var DataBlock = new List<byte>();

                DataBlock.AddRange(idbytes);
                DataBlock.InsertRange(8, natioanlIdbytes);
                byte[] Data = DataBlock.ToArray();// data is compelete



                byte[] KeyA, KeyB, TailBlock;
                int cserial = BitConverter.ToInt32(cardSN, 0);
                generateKeys(cserial, out KeyA, out KeyB, out TailBlock);

                byte[] KeyA2, KeyB2, TailBlock2;
                int cserial2 = BitConverter.ToInt32(cardSN, 0);
                generateKeys2(cserial2, out KeyA2, out KeyB2, out TailBlock2);

                var listkeyA = new List<byte>();
                listkeyA.AddRange(KeyA);
                listkeyA.Insert(0, 0);
                listkeyA.Insert(0, 0);

                var listkeyB = new List<byte>();
                listkeyB.AddRange(KeyB);
                listkeyB.Insert(0, 0);
                listkeyB.Insert(0, 0);

                this.KeyA = BitConverter.ToInt64(listkeyA.ToArray(), 0);
                this.KeyB = BitConverter.ToInt64(listkeyB.ToArray(), 0);

                int block = 0;

                if (MifareAPI.MF_Authentication(0, authenTypeB, 3, ref cardSN[0]) == 0)
                {
                    if (MifareAPI.MF_Read(0, 0, 1, ref SectorZero[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 1, 1, ref Data[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 2, 1, ref Data[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 3, 1, ref TailBlock[0]) == 0)
                        block++;
                }

                if (MifareAPI.MF_LoadKey(0, ref Ckey[0]) == 0)
                {
                    for (short Sector = 1; Sector < 16; Sector++)
                    {
                        short Authblocknumber = (short)(((Sector + 1) * 4) - 1);

                        if (MifareAPI.MF_Authentication(0, authenTypeB, Authblocknumber, ref cardSN[0]) == 0)
                        {
                            if (MifareAPI.MF_Write(0, Authblocknumber, 1, ref TailBlock2[0]) == 0)
                                block++;
                        }
                    }
                }
                if (block == 19)
                    return true;
            }
            return false;
        }

        public void generateKeysX(int CardSerialnumber, out byte[] KeyA, out byte[] KeyB, out byte[] TailBlock)
        {
            ///tak karte aval be shekl zir kod shode
            //    ///             TailBlock.Add(fourbyteArray[3]);
            //    TailBlock.AddRange(new byte[6]
            //            { fourbyteArray[2], fourbyteArray[3] ,
            //              fourbyteArray[3], fourbyteArray[2], fourbyteArray[1], fourbyteArray[0]
            //});

            int xorMate = 0xf85ec7b ^ CardSerialnumber;
            byte[] fourbyteArray = BitConverter.GetBytes(xorMate);
            KeyA = new byte[6]{ fourbyteArray[2], fourbyteArray[3],
                                            fourbyteArray[3], fourbyteArray[2],
                                            fourbyteArray[1], fourbyteArray[0]
                                            };

            byte[] Accessarea = new byte[] { 0x78, 0x77, 0x88, 0x01 };
            KeyB = new byte[] { 0xd5, 0x48, 0x39, 0xfa, 0xe7, 0xc2 };
            List<byte> tail = new List<byte>();
            tail.AddRange(KeyA);
            tail.InsertRange(6, Accessarea);
            tail.InsertRange(10, KeyB);

            TailBlock = tail.ToArray();
        }
        public void generateKeys2X(int CardSerialnumber, out byte[] KeyA, out byte[] KeyB, out byte[] TailBlock)
        {
            ///tak karte aval be shekl zir kod shode
            //    ///             TailBlock.Add(fourbyteArray[3]);
            //    TailBlock.AddRange(new byte[6]
            //            { fourbyteArray[2], fourbyteArray[3] ,
            //              fourbyteArray[3], fourbyteArray[2], fourbyteArray[1], fourbyteArray[0]
            //});

            int xorMate = 0xc5086fa ^ CardSerialnumber;
            byte[] fourbyteArray = BitConverter.GetBytes(xorMate);
            KeyA = new byte[6]{ fourbyteArray[3], fourbyteArray[1],
                                            fourbyteArray[2], fourbyteArray[3],
                                            fourbyteArray[0], fourbyteArray[1]
                                            };

            byte[] Accessarea = new byte[] { 0x78, 0x77, 0x88, 0x01 };
            KeyB = new byte[] { 0xbc, 0x46, 0xfd, 0x84, 0x38, 0xbd };
            List<byte> tail = new List<byte>();
            tail.AddRange(KeyA);
            tail.InsertRange(6, Accessarea);
            tail.InsertRange(10, KeyB);

            TailBlock = tail.ToArray();
        }
        public bool ActivateRawCardX(out byte[] SectorZero,long NationalID)
        {
            SectorZero = new byte[16];
            Ckey[0] = 0xff;
            Ckey[1] = 0xff;
            Ckey[2] = 0xff;
            Ckey[3] = 0xff;
            Ckey[4] = 0xff;
            Ckey[5] = 0xff;
            if (MifareAPI.MF_LoadKey(0, ref Ckey[0]) == 0)
            {
                // if (MifareAPI.MF_Authentication(0, authenType, 3, ref cardSN[0]) == 0)
                // {

                var idbytes = BitConverter.GetBytes(NationalID);
                var natioanlIdbytes = BitConverter.GetBytes(NationalID);
                var DataBlock = new List<byte>();
                DataBlock.AddRange(idbytes);
                DataBlock.InsertRange(8, natioanlIdbytes);

                byte[] Data = DataBlock.ToArray();// data is compelete



                byte[] KeyA, KeyB, TailBlock;
                int cserial = BitConverter.ToInt32(cardSN, 0);
                generateKeysX(cserial, out KeyA, out KeyB, out TailBlock);

                byte[] KeyA2, KeyB2, TailBlock2;
                int cserial2 = BitConverter.ToInt32(cardSN, 0);
                generateKeys2X(cserial2, out KeyA2, out KeyB2, out TailBlock2);

                var listkeyA = new List<byte>();
                listkeyA.AddRange(KeyA);
                listkeyA.Insert(0, 0);
                listkeyA.Insert(0, 0);

                var listkeyB = new List<byte>();
                listkeyB.AddRange(KeyB);
                listkeyB.Insert(0, 0);
                listkeyB.Insert(0, 0);

                this.KeyA = BitConverter.ToInt64(listkeyA.ToArray(), 0);
                this.KeyB = BitConverter.ToInt64(listkeyB.ToArray(), 0);

                int block = 0;

                if (MifareAPI.MF_Authentication(0, authenTypeB, 3, ref cardSN[0]) == 0)
                {
                    if (MifareAPI.MF_Read(0, 0, 1, ref SectorZero[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 1, 1, ref Data[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 2, 1, ref Data[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 3, 1, ref TailBlock[0]) == 0)
                        block++;
                }

                if (MifareAPI.MF_LoadKey(0, ref Ckey[0]) == 0)
                {
                    for (short Sector = 1; Sector < 16; Sector++)
                    {
                        short Authblocknumber = (short)(((Sector + 1) * 4) - 1);

                        if (MifareAPI.MF_Authentication(0, authenTypeB, Authblocknumber, ref cardSN[0]) == 0)
                        {
                            if (MifareAPI.MF_Write(0, Authblocknumber, 1, ref TailBlock2[0]) == 0)
                                block++;
                        }
                    }
                }
                if (block == 19)
                    return true;
            }
            return false;
        }
        internal bool ResetCardX()
        {
            byte[] KeyA, KeyB, TailBlock;
            byte[] KeyA2, KeyB2, TailBlock2;
            int cserial = BitConverter.ToInt32(cardSN, 0);

            generateKeys(cserial, out KeyA, out KeyB, out TailBlock);
            generateKeys2(cserial, out KeyA2, out KeyB2, out TailBlock2);

            byte[] Data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            TailBlock = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x07, 0x80, 0x69, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };


            if (MifareAPI.MF_LoadKey(0, ref KeyB[0]) == 0)
            {
                int block = 0;
                if (MifareAPI.MF_Authentication(0, authenTypeB, 3, ref cardSN[0]) == 0)
                {
                    if (MifareAPI.MF_Write(0, 1, 1, ref Data[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 2, 1, ref Data[0]) == 0)
                        block++;
                    if (MifareAPI.MF_Write(0, 3, 1, ref TailBlock[0]) == 0)
                        block++;
                }
                if (MifareAPI.MF_LoadKey(0, ref KeyB2[0]) == 0)
                {
                    for (short Sector = 1; Sector < 16; Sector++)
                    {
                        short Authblocknumber = (short)(((Sector + 1) * 4) - 1);

                        if (MifareAPI.MF_Authentication(0, authenTypeB, Authblocknumber, ref cardSN[0]) == 0)
                        {
                            if (MifareAPI.MF_Write(0, Authblocknumber, 1, ref TailBlock[0]) == 0)
                                block++;
                        }
                    }
                }
                if (block == 18)
                    return true;
            }
            return false;
        }
    }
}
