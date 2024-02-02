using Practices.Models;
using Practices.Business;
using Practices.Data;
using Practices.Presentation;


IUserRepository userRepository = new UserRepository();
ICompanyRepository companyRepository = new CompanyRepository();
IUserService userService = new UserService(userRepository);
//ICompanyService companyService = new CompanyService(companyRepository);
MainMenu mainMenu = new(userService);
mainMenu.RegistrationMenu();

