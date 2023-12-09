# BookStore Project

Welcome to the BookStore project! This project is developed as part of the requirements for the Advanced Software Design and Development course, focusing on ASP.NET Core technology. The BookStore application is designed to manage and organize a collection of books, providing a user-friendly interface for users to browse, search, and purchase books.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features
- **User Authentication:** Secure user authentication system for registered users.
- **Book Management:** Add, edit, and delete books from the inventory.
- **Search and Filters:** Easily search for books and apply filters to find specific genres, authors, or titles.
- **Shopping Cart:** Users can add books to their shopping cart for a seamless shopping experience.
- **Order History:** Track and view past orders and transactions.
- **Responsive Design:** The application is designed to be accessible and functional on various devices.

## Technologies Used
- **ASP.NET Core:** The core framework for building the web application.
- **Entity Framework Core:** Object-relational mapping (ORM) for database interaction.
- **HTML, CSS, JavaScript:** Front-end development technologies for a dynamic and interactive user interface.
- **Bootstrap:** Front-end framework for responsive and visually appealing design.
- **SQL Server:** Database management system for storing and retrieving book information.
- **Git:** Version control system for collaborative development.

## Getting Started
To set up and run the BookStore project on your local machine, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/BookStore.git
   cd BookStore
   ```

2. Install dependencies:
   ```bash
   dotnet restore
   ```

3. Update the database:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Open your web browser and navigate to `http://localhost:5000` to access the BookStore application.

## Usage
- **User Registration/Login:** Create a new account or log in if you are a returning user.
- **Browse Books:** Explore the collection of books using search and filters.
- **Add to Cart:** Select books and add them to your shopping cart.
- **Checkout:** Complete the purchase by providing necessary details.
- **View Order History:** Track your order history and view details of past transactions.

## Contributing
Contributions are welcome! If you have ideas for new features, improvements, or bug fixes, please open an issue or submit a pull request. Follow the [Contributing Guidelines](CONTRIBUTING.md) for more details.

## License
This project is licensed under the [MIT License](LICENSE.md). Feel free to use, modify, and distribute the code for educational and non-commercial purposes.

Happy reading and coding! 📚💻
