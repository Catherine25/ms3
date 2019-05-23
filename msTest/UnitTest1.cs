using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Diagnostics.Debug;

namespace msTest
{
    [TestClass]
    public class msUnitTest
    {
        [TestMethod]
        public async Task BookLoader_loadDataFromURLAsync_CorrectLinkAsync()
        {
            string correctLink = "http://ec2-18-130-203-173.eu-west-2.compute.amazonaws.com/ms.json";

            ObservableCollection<ms.Data.Book> books =
                await ms.Data.BookLoader.loadDataFromURLAsync
                (correctLink);
            
            Assert(books != null);
        }
        

        [TestMethod]
        public async Task BookLoader_loadDataFromURLAsync_InvalidLinkAsync()
        {
            string invalidLink = "http://ec2--18-130-203-173.eu-west-2.compute.amazonaws.com/ms.json";

            ObservableCollection<ms.Data.Book> books =
                await ms.Data.BookLoader.loadDataFromURLAsync
                (invalidLink);

            Assert(books == null);
        }

        [TestMethod]
        public void BookLoader_parseToJSON_parseToObject()
        {
            ObservableCollection<ms.Data.Book> test = new ObservableCollection<ms.Data.Book>(),
                result = new ObservableCollection<ms.Data.Book>();

            string json;

            int num = 5;

            for (int i = 0; i < num; i++)
                test.Add(new ms.Data.Book());

            json = ms.Data.BookLoader.parseToJSON(test);

            result = ms.Data.BookLoader.parseToObject(json);

            Assert(test == result);
        }
    }
}
