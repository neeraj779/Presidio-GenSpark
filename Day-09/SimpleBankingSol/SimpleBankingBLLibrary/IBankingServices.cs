﻿namespace SimpleBankingBLLibrary
{
    public interface IBankingServices
    {
        void RegisterUser(string username, double initialBalance, string password);
        bool AuthenticateUser(string username, string password);
        void Deposit(string username, double amount);
        void Withdraw(string username, double amount);
        void Transfer(string sender, string receiver, double amount);
        double CheckBalance(string username);
        void CheckTransactionHistory(string username);
    }
}
