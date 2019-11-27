import webdriver, {Builder, By, Key, until, util} from "selenium-webdriver";
 export default class SignInPage {
  constructor() {
    this.loginUrl = "https://enterprise.dev.juice.net/";
    this.resellerPassword = "12qw!@QW";
    this.resellerEmail = "parkhval+r4alfa@gmail.com";
    this.pathToLXLSFile = `${__dirname}/users.xlsx`;
    
    //region LOGIN FORM
    this.emailFieldID = 'username';
    this.passwordFieldID = 'password';
    this.submitLoginButtonXpath  = "login-submit";
    this.createNewClientButtonXpath =   "//fab-button";
    this.resellerDashboardUrl = this.loginUrl +  "/companies";
    //endregion
    //region #########NEW CLIENT FORM###################
    this.nameFieldXpath = "//input[@formcontrolname = 'name']";
    this.emailFieldXpath = "//input[@formcontrolname = 'email']";
    this.adminFirstName = "//input[@formcontrolname = 'adminFirstName']";
    this.adminLastName = "//input[@formcontrolname = 'adminLastName']";
    this.currency = "//mat-select[@formcontrolname = 'currency']";
    this.dollarSpanXpath = "//span[text() = ' United states dollar ']";
    this.address = "//input[@formcontrolname = 'address']";
    this.city = "//input[@formcontrolname = 'city']";
    this.state = "//input[@formcontrolname = 'state']";
    this.zipCode = "//input[@formcontrolname = 'zip']";  
    this.timeZone = "//mat-select[@formcontrolname = 'timeZone']";
    this.createButton = "//button/span[text() = 'Create']";
    this.viewClientsButton = "//button/span[text()= 'View clients']/..";
  //endregion ##############################################




  }



}
