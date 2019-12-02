import webdriver, {Builder, By, Key, until, util} from "selenium-webdriver";
 export default class SignInPage {

  constructor() {
    const today = new Date();
    const clientName = "client autotest"  + today;

    this.loginUrl = "https://enterprise.dev.juice.net";
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
    this.timeZone = "//mat-select[@formcontrolname = 'timeZone']";
    this.createButton = "//button/span[text() = 'Create']";
    this.viewClientsButton = "//flat-button/button/span[text() = 'View clients']";
    this.sortButton = "//span[text() = 'Client Name']";
    // this.createdClientInList = "//datatable-scroller/datatable-row-wrapper/datatable-body-row/div/datatable-body-cell  /div/a[text()='" + clientName + "']/../../../datatable-body-cell/div/a[text() = ' Login as Client ']";
  //endregion ##############################################

      this.ratesMenuOption = "//a[@href = '/rates']";
      this.freeRateHref = "//a[@href = '/rates/00000000-0000-0000-0000-000000000000']";
      this.globalAddButtonXpath = "//fab-button/a[@class = 'accent add']";
      this.newRateSpan = "//button/span[text() = 'New rate']/..";
      this.rateName = "//input[@name = 'name']";
      this.saveRateButton = "//flat-button/button/span[text()='Done']";
      this.rateNameString = "Autotest name";
      this.createdRateXpath = "//a[text() = '"+ this.rateNameString +"']";
      this.saveOnEditButton = "//flat-button[@icon = 'icon-save']";
      this.alertOkButton = "//flat-button/button/span[text() = 'Ok']/../..";
      this.editRateName = "//input[@formcontrolname = 'name']";




  }



}
