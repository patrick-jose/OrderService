using OrderServce.CrossCutting;
using OrderService.CrossCutting;
using OrderService.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class MessagesTest
    {
        private ISend _sendService;
        private IReceive _receiveService;

        [TestMethod]
        public void SendTest()
        {
            _sendService = new Send();
            _receiveService = new Receive();

            _sendService.SendMessage("test");
            _receiveService.ReceiveMessage();

            //Assert.IsNotNull();
            //Assert.IsTrue(result.Result.Any());
        }
    }
}
