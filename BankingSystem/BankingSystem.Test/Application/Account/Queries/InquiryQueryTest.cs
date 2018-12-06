using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Test.Application.Account.Queries
{
    public class InquiryQueryTest
    {
        //[TestCase(0)]
        //[TestCase(-1)]
        //[TestCase(-2)]
        //[TestCase(-3)]
        //public void Balance_GivenZeroOrNegativeNumber_Should_BusinessServerErrorException(int accountNumber)
        //{
        //    //Arr
        //    //Act
        //    var result = Assert.Throws<BusinessServerErrorException>(() => accountBusiness.Balance(accountNumber));

        //    //Assert
        //    result.ShouldNotBeNull();
        //    result.Message.ShouldContain(AppMessages.AccountNumberNegative);
        //}

        //[TestCase(101)]
        //[TestCase(100)]
        //[TestCase(200)]
        //[TestCase(300)]
        //public void Balance_GivenPositiveAccountNumberButNotExisted_ShouldBusinessServerErrorException(int accountNumber)
        //{
        //    //Arr
        //    dbcontextMock.Setup(a => a.Set<BankAccount>())
        //        .Returns(new FakeDbSet<BankAccount>(Builder<BankAccount>.CreateListOfSize(30).Build()));
        //    //Act
        //    var result = Assert.Throws<BusinessServerErrorException>(() => accountBusiness.Balance(accountNumber));

        //    //Assert
        //    result.ShouldNotBeNull();
        //    result.Message.ShouldContain(string.Format(AppMessages.AccountDoesntExistOrInactive, accountNumber));

        //    dbcontextMock.Verify(a => a.Set<BankAccount>(), Times.Once);
        //    dbcontextMock.Verify(a => a.Set<TransactionHistory>(), Times.Never);
        //}

        //[TestCase(1)]
        //[TestCase(2)]
        //[TestCase(3)]
        //[TestCase(4)]
        //[TestCase(5)]
        //public void Balance_GivenExistedPositiveAccountNumber_ShouldReturnGoodResponseData(int accountNumber)
        //{
        //    //Arr
        //    dbcontextMock.Setup(a => a.Set<BankAccount>())
        //        .Returns(new FakeDbSet<BankAccount>(Builder<BankAccount>.CreateListOfSize(5).All().With(a => a.IsActive = true).Build()));
        //    dbcontextMock.Setup(a => a.Set<TransactionHistory>())
        //      .Returns(new FakeDbSet<TransactionHistory>(Builder<TransactionHistory>.CreateListOfSize(2).Build()));
        //    //Act
        //    var result = accountBusiness.Balance(accountNumber);

        //    //Assert
        //    result.ShouldNotBeNull();
        //    result.AccountNumber.ShouldBe(accountNumber);
        //    result.Message.ShouldNotBeNullOrEmpty();

        //    dbcontextMock.Verify(a => a.Set<BankAccount>(), Times.Once);
        //    dbcontextMock.Verify(a => a.Set<TransactionHistory>(), Times.Once);
        //    dbcontextMock.Verify(a => a.CommitChanges(), Times.Once);
        //}
    }
}
