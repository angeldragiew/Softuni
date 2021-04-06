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
            item = new Item("Angel", "1");
        }

        [Test]
        public void AddItemThrows_When_CellDoesntExist()
        {
            Assert.That(() =>
            {
                bankVault.AddItem("123", item);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void AddItemThrows_When_CellIsAlreadyTaken()
        {
            bankVault.AddItem("A1", new Item("A", "A"));
            Assert.That(() =>
            {
                bankVault.AddItem("A1", item);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell is already taken!"));
        }

        [Test]
        public void AddItemThrows_When_ItemIsAlreadyInCell()
        {
            bankVault.AddItem("A1", item);
            Assert.That(() =>
            {
                bankVault.AddItem("A2", item);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Item is already in cell!"));
        }

        [Test]
        public void AddItem_ShouldSetCorrectly_WhenDataIsValid()
        {
            bankVault.AddItem("A1", item);

            Assert.That(item, Is.EqualTo(bankVault.VaultCells["A1"]));
        }

        [Test]
        public void RemoveItemThrows_When_CellDoesNotExist()
        {
            Assert.That(() =>
            {
                bankVault.RemoveItem("123", item);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void RemoveItemThrows_When_ItemInThatCellDoesNotExist()
        {
            bankVault.AddItem("A1", new Item("achko", "asd"));
            Assert.That(() =>
            {
                bankVault.RemoveItem("A1", item);
            }, Throws.ArgumentException.With.Message.EqualTo($"Item in that cell doesn't exists!"));
        }

        [Test]
        public void RemoveItem_ShouldRemoveItemSuccessfully_WhenDataIsValid()
        {
            bankVault.AddItem("A1", item);

            bankVault.RemoveItem("A1", item);

            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(null));
        }
    }
}