using System;
using System.IO;
using EasyArchitecture.Common;
using EasyArchitecture.Internal;
using EasyArchitecture.Mechanisms;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Mechanisms
{
    [TestFixture]
    public class StorageTest
    {
        private FileInfo file;

        [SetUp]
        public void SetUp()
        {
            Configure
                .For("Application4Test")
                .Done();

            LocalThreadStorage.SetCurrentModuleName("Application4Test");

         //   _key = Guid.NewGuid().ToString();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"Stuff\File", "Metallica-SadButTrue.txt");
            file = new FileInfo(filePath);

        }

        [Test]
        public void Should_store_file()
        {
            //load file from disck

            var buffer = new byte[10000];
            var n = file.OpenRead().Read(buffer,0,(int) file.Length);
            Guid? id = null;

            Assert.That(() => { id = Storage.Save(buffer); },Throws.Nothing);
            Assert.That( id , Is.Not.Null);
            
            

            //Storage.This(id).Exists();
            //Storage.This(id).Get();

        }

        //[Test]
        //public void Should_store_file()
        //{
        //    //load file from disck
        //    var buffer = new byte[100];

        //    var id = Storage.Save(buffer);


        //    //Storage.This(id).Exists();
        //    //Storage.This(id).Get();

        //}

    }
}