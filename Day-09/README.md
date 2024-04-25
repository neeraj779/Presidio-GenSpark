# Simple Banking Application

## Objective:
Create a console-based banking application in C# that allows users to perform basic banking operations such as creating an account, depositing funds, withdrawing funds, and checking the account balance.

## Functional Requirements:

1. **User Registration:**
   - Users should be able to register by providing a unique username and a starting balance.
   - Usernames must be unique.

2. **Account Operations:**
   - Each registered user should have their own account to manage.
   - Users should be able to transfer money from their account to another account.
   - Users should be able to check their account balance.

3. **Error Handling:**
   - Ensure that appropriate error messages are displayed for invalid user inputs or operations.

4. **Persistence:**
   - Account information should be stored in memory using collections like `List` or `Dictionary`.

## Non-Functional Requirements:

1. **User Interface:**
   - The user interface should be simple and easy to understand, with clear instructions provided for each operation.

2. **Efficiency:**
   - The application should handle operations efficiently, avoiding unnecessary resource consumption.

3. **Security:**
   - Ensure that sensitive user information like account balances is not exposed to unauthorized users.

4. **Scalability:**
   - Design the application to easily accommodate future enhancements or changes in requirements.

### Optional Enhancements (Not required but could be added for further functionality):

1. **Transaction History:**
   - Implement a feature to track and display the transaction history for each user.

2. **User Authentication:**
   - Implement a login system with passwords to enhance security.

3. **File Storage:**
   - Store account information persistently in files to maintain data across application sessions.

4. **Data Validation:**
   - Implement robust input validation to prevent incorrect data entry by users.
