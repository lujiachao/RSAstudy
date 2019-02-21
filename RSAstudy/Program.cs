using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using XC.RSAUtil;

namespace RSAstudy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateRSAKey();
            //#region xml转化为pkcs1
            //string privateKeyXml = RsaKeyGenerator.XmlKey(2048)[0];
            //string publicKeyXml = RsaKeyGenerator.XmlKey(2048)[1];
            //ConversionRSAKey(privateKeyXml, publicKeyXml, EnumConversionType.XML转化为Pkcs1, ConversionRSAKeyFunc);
            //#endregion
            //#region xml转化为pkcs8
            //string privateKeyXml = RsaKeyGenerator.XmlKey(2048)[0];
            //string publicKeyXml = RsaKeyGenerator.XmlKey(2048)[1];
            //ConversionRSAKey(privateKeyXml, publicKeyXml, EnumConversionType.XML转化为Pkcs8, ConversionRSAKeyFunc);
            //#endregion
            //#region pkcs1转化为xml
            //List<string> list = RsaKeyGenerator.Pkcs1Key(2048, false);
            //string privateKeyPkcs1 = list[0];
            //string publicKeyPkcs1 = list[1];
            //ConversionRSAKey(privateKeyPkcs1, publicKeyPkcs1, EnumConversionType.Pkcs1转化为XML, ConversionRSAKeyFunc);
            //#endregion
            //#region pkcs1 转化为 pkcs8
            //List<string> list = RsaKeyGenerator.Pkcs1Key(2048, false);
            //string privateKeyPkcs1 = list[0];
            //string publicKeyPkcs1 = list[1];
            //ConversionRSAKey(privateKeyPkcs1, publicKeyPkcs1, EnumConversionType.Pkcs1转化为Pkcs8, ConversionRSAKeyFunc);
            //#endregion
            //#region pkcs8 转化为 XML
            //List<string> list = RsaKeyGenerator.Pkcs8Key(2048, false);
            //string privateKeyPkcs8 = list[0];
            //string publicKeyPkcs8 = list[1];
            //ConversionRSAKey(privateKeyPkcs8, publicKeyPkcs8, EnumConversionType.Pkcs8转化为XML, ConversionRSAKeyFunc);
            //#endregion
            //#region pkcs8 转化为 Pkcs1
            //List<string> list = RsaKeyGenerator.Pkcs8Key(2048, false);
            //string privateKeyPkcs8 = list[0];
            //string publicKeyPkcs8 = list[1];
            //ConversionRSAKey(privateKeyPkcs8, publicKeyPkcs8, EnumConversionType.Pkcs8转化为Pkcs1, ConversionRSAKeyFunc);
            //#endregion
            //#region xml
            //List<string> list = RsaKeyGenerator.XmlKey(2048);
            //var privateKeyXml = list[0];
            //var publicKeyXml = list[1];
            //RSASign(privateKeyXml,publicKeyXml, EnumUserType.xml, RSASignFunc);
            //#endregion
            //#region xml
            //List<string> list = RsaKeyGenerator.Pkcs1Key(2048,false);
            //var privateKeyPkcs1 = list[0];
            //var publicKeyPkcs1 = list[1];
            //RSASign(privateKeyPkcs1, publicKeyPkcs1, EnumUserType.pkcs1, RSASignFunc);
            //#endregion
            //#region xml
            //List<string> list = RsaKeyGenerator.Pkcs8Key(2048, false);
            //var privateKeyPkcs8 = list[0];
            //var publicKeyPkcs8 = list[1];
            //RSASign(privateKeyPkcs8,publicKeyPkcs8, EnumUserType.pkcs8, RSASignFunc);
            //#endregion
            Console.ReadKey();
        }

        /// <summary>
        /// 生成公私钥对
        /// </summary>
        public static void CreateRSAKey()
        {
            var keyList = RsaKeyGenerator.XmlKey(2048);
            var privateKey = keyList[0];
            var publicKey = keyList[1];
            // XML
            Console.WriteLine(RsaKeyGenerator.XmlKey(2048)[0]);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(RsaKeyGenerator.XmlKey(2048)[1]);
            Console.WriteLine("================================================================================");
            // Pkcs1
            Console.WriteLine(RsaKeyGenerator.Pkcs1Key(2048, true)[0]);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(RsaKeyGenerator.Pkcs1Key(2048, true)[1]);
            Console.WriteLine("================================================================================");
            // Pkcs8
            Console.WriteLine(RsaKeyGenerator.Pkcs8Key(2048, true)[0]);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(RsaKeyGenerator.Pkcs8Key(2048, true)[1]);

            Console.ReadKey();
        }

        /// <summary>
        /// 不同格式之间的公私钥对的相互转换  
        /// </summary>
        public static void ConversionRSAKey(string privateKey, string publicKey, EnumConversionType enumConversionType, Action<string,string, EnumConversionType> conversion)
        {
            conversion(privateKey, publicKey, enumConversionType);
        }

        //封装方法，实现委托
        public static void ConversionRSAKeyFunc(string privateKey, string publicKey, EnumConversionType enumConversionType)
        {
            if (enumConversionType == EnumConversionType.XML转化为Pkcs1)
            {
                if (!string.IsNullOrWhiteSpace(privateKey))
                {
                    Console.WriteLine(privateKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PrivateKeyXmlToPkcs1(privateKey));
                }
                if (!string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine(publicKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PublicKeyXmlToPem(privateKey));
                }
                if (string.IsNullOrWhiteSpace(privateKey) && string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine("请输入正确的公私钥");
                }
            }
            else if (enumConversionType == EnumConversionType.XML转化为Pkcs8)
            {
                if (!string.IsNullOrWhiteSpace(privateKey))
                {
                    Console.WriteLine(privateKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PrivateKeyXmlToPkcs8(privateKey));
                }
                if (!string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine(publicKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PublicKeyXmlToPem(privateKey));
                }
                if (string.IsNullOrWhiteSpace(privateKey) && string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine("请输入正确的公私钥");
                }
            }
            else if (enumConversionType == EnumConversionType.Pkcs1转化为XML)
            {
                if (!string.IsNullOrWhiteSpace(privateKey))
                {
                    Console.WriteLine(privateKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PrivateKeyPkcs1ToXml(privateKey));
                }
                if (!string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine(publicKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PublicKeyPemToXml(publicKey));
                }
                if (string.IsNullOrWhiteSpace(privateKey) && string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine("请输入正确的公私钥");
                }
            }
            else if (enumConversionType == EnumConversionType.Pkcs1转化为Pkcs8)
            {
                if (!string.IsNullOrWhiteSpace(privateKey))
                {
                    Console.WriteLine(privateKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PrivateKeyPkcs1ToPkcs8(privateKey));
                }
                if (!string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine("No conversion required");
                }
                if (string.IsNullOrWhiteSpace(privateKey) && string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine("请输入正确的公私钥");
                }
            }
            else if (enumConversionType == EnumConversionType.Pkcs8转化为XML)
            {
                if (!string.IsNullOrWhiteSpace(privateKey))
                {
                    Console.WriteLine(privateKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PrivateKeyPkcs8ToXml(privateKey));
                }
                if (!string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine(publicKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PublicKeyPemToXml(publicKey));
                }
                if (string.IsNullOrWhiteSpace(privateKey) && string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine("请输入正确的公私钥");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(privateKey))
                {
                    Console.WriteLine(privateKey);
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine(RsaKeyConvert.PrivateKeyPkcs8ToPkcs1(privateKey));
                }
                if (!string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine("No conversion required");
                }
                if (string.IsNullOrWhiteSpace(privateKey) && string.IsNullOrWhiteSpace(publicKey))
                {
                    Console.WriteLine("请输入正确的公私钥");
                }
            }
        }

        /// <summary>
        /// 不同格式加解密以及验签和签名
        /// </summary>
        public static void RSASign(string privateKey, string publicKey, EnumUserType enumUserType, Action<string,string,EnumUserType> rsaSign)
        {
            rsaSign(privateKey, publicKey, enumUserType);
        }

        /// <summary>
        /// RSA 加密,解密，签名和验签
        /// </summary>
        public static void RSASignFunc(string privateKey, string publicKey, EnumUserType enumUserType)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            switch (enumUserType)
            {
                case EnumUserType.xml:
                    RsaXmlUtil rsaXmlUtil = new RsaXmlUtil(Encoding.UTF8, publicKey,privateKey);
                    var encrypt = rsaXmlUtil.Encrypt("123456789", RSAEncryptionPadding.Pkcs1);
                    var encryptInput = rsaXmlUtil.Decrypt(encrypt, RSAEncryptionPadding.Pkcs1);
                    Console.Write("XML加解密是否成功:");
                    Console.WriteLine(encryptInput is "123456789");
                    var sign = rsaXmlUtil.SignData("987654321", HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    var verifyData = rsaXmlUtil.VerifyData("987654321",sign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    Console.Write("XML签名是否成功");
                    Console.WriteLine(verifyData);
                    break;
                case EnumUserType.pkcs1:
                    RsaPkcs1Util rsaPkcs1Util = new RsaPkcs1Util(Encoding.UTF8, publicKey, privateKey);
                    var encrypt2 = rsaPkcs1Util.Encrypt("123456789", RSAEncryptionPadding.Pkcs1);
                    var encryptInput2 = rsaPkcs1Util.Decrypt(encrypt2, RSAEncryptionPadding.Pkcs1);
                    Console.Write("PKCS1加解密是否成功:");
                    Console.WriteLine(encryptInput2 is "123456789");
                    var sign2 = rsaPkcs1Util.SignData("987654321", HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    var verifyData2 = rsaPkcs1Util.VerifyData("987654321", sign2, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    Console.Write("PKCS1签名是否成功");
                    Console.WriteLine(verifyData2);
                    break;
                default :
                    RsaPkcs8Util rsaPkcs8Util = new RsaPkcs8Util(Encoding.UTF8, publicKey, privateKey);
                    var encrypt3 = rsaPkcs8Util.Encrypt("123456789", RSAEncryptionPadding.Pkcs1);
                    var encryptInput3 = rsaPkcs8Util.Decrypt(encrypt3, RSAEncryptionPadding.Pkcs1);
                    Console.Write("PKCS8加解密是否成功:");
                    Console.WriteLine(encryptInput3 is "123456789");
                    var sign3 = rsaPkcs8Util.SignData("987654321", HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    var verifyData3 = rsaPkcs8Util.VerifyData("987654321", sign3, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    Console.Write("PKCS8签名是否成功");
                    Console.WriteLine(verifyData3);
                    break;
            }          
        }

        public static string RSAencryupt(RSAUtilBase rSAUtilBase, RSAEncryptionPadding rSAEncryptionPadding, string data) => rSAUtilBase.Encrypt(data, rSAEncryptionPadding);
    }
}
