using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Gosho", "51");
        }

        [Test]
        public void Ctor()
        {
            Assert.AreEqual(bankVault.VaultCells.Count, 12);
        }

        [Test]
        public void AddItem_ThrowExceptionForCellExist()
        {
            Assert.Throws<ArgumentException>((() => bankVault.AddItem("G5", item)));
        }

        [Test]
        public void AddItem_ThrowExceptionForCellTaken()
        {
            Item item1 = new Item("Pesho", "31");
            bankVault.AddItem("A1",item1);

            Assert.Throws<ArgumentException>((() => bankVault.AddItem("A1", item)));
        }

        [Test]
        public void AddItem_ThrowExceptionForItemExist()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>((() => bankVault.AddItem("A2", item)));
        }

        [Test]
        public void AddItem_ReturnTheRightOutput()
        {
            Assert.AreEqual($"Item:{item.ItemId} saved successfully!", bankVault.AddItem("A1", item));
        }

        [Test]
        public void RemoveItem_CellDoesnNotExists()
        {
            Assert.Throws<ArgumentException>((() => bankVault.RemoveItem("G1", item)));
        }
        [Test]
        public void RemoveItem_ItemDoesnNotExists()
        {
            Assert.Throws<ArgumentException>((() => bankVault.RemoveItem("A1", item)));
        }

        [Test]
        public void RemoveItem_SuccessfullRemove()
        {
            bankVault.AddItem("A1", item);

            Assert.AreEqual($"Remove item:{item.ItemId} successfully!", bankVault.RemoveItem("A1", item));
        }
    }
}