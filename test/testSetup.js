import webdriver, {Builder, By, Key, until} from "selenium-webdriver";
 export default class SignInPage {

  constructor() {
    const today = new Date();
    const clientName = "client autotest"  + today;
    this.locationName = "Autotest location " + today;
    const clientEmail = "parkhval+c" + today.getDay() + today.getHours() +  today.getMinutes() +  "betaautotest@gmail.com";
    const userEmail = "6dofik+c" + today.getDay() + today.getHours() +  today.getMinutes() +  "betaautotest@gmail.com";
    this.userName = "AutoTest_user" + today.getDay() + today.getHours() +  today.getMinutes();
    this.userSurName = "AutoTest_SurName";
    this.changedUserName = "+Vasya";
    this.changedUserSurName = "+Pumpkin";
    this.loginUrl = "https://enterprise-new.dev.juice.net/";
    this.resellerPassword = "12qw!@QW";
    this.resellerEmail = "parkhval+r1alfaauto@gmail.com";
    this.clientEmail = "6dofik+c10n@gmail.com";
    this.clientPassword= "emotorwerks";
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
    this.zipCode = "//input[@id='input-zip']";
    this.timeZone = "//mat-select[@formcontrolname = 'timeZone']";
    this.createButton = "//button/span[text() = 'Create']";
    this.viewClientsButton = "//flat-button/button/span[text()='View clients']";
    this.sortButton = "//span[text() = 'Client Name']";
    // this.createdClientInList = "//datatable-scroller/datatable-row-wrapper/datatable-body-row/div/datatable-body-cell  /div/a[text()='" + clientName + "']/../../../datatable-body-cell/div/a[text() = ' Login as Client ']";
  //endregion ##############################################
//region RATE
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
//endregion

//region groups
      this.groupsMenuOption = "//a[@href = '/users/groups']";
      this.newGroupSpan = "//button/span[text() = 'New group']/..";
      this.groupNameInput = "//input[@name='name']";
      this.groupCreationNextStepButton = "//flat-button/button/span[text()='Next']";
      this.groupCreationDoneButton = "//flat-button/button/span[text()='Done']";
      this.createdGroup = "//a[text()='Autotest user group']";
      this.editGroupNameField = "//input[@formcontrolname = 'name']";
      this.usersTabOfGroups = "//div[text()= 'Users']";
      this.assignNewUSerButton = "(//fab-button)[2]";
      this.userSearchInput = "//input";
      this.searchUserButton = "//button[@class = 'mat-icon-button']/span/mat-icon";
      this.selectUserCheckbox = "//mat-pseudo-checkbox";
      this.saveUserSearchButton = "//flat-button/button/span[text()='Save']";
      this.deleteGroupButton = "//flat-button/button/span[text()='Delete']";
      this.confirmDeleteButton = "(//flat-button/button/span[text()='Delete'])[2]/../..";
//endregion
    //region locations

    this.locationsMenuOption = "//a[@href = '/locations']";
    this.newLocationSpan = "//button/span[text() = 'New location']/..";
    this.locationNameFieldXpath = "//input[@formcontrolname = 'name']";
    this.locationCreateNextButton = "//flat-button/button/span[text()='Next']";
    this.locationCreateDoneButton = "//flat-button/button/span[text()='Done']";
    this.viewLocationsButton = "//flat-button/button/span[text()='View locations']";
    this.createdLocationInTable = "//tbody/tr/td/div/div/div/a[text()='" + this.locationName + "']";
    this.sublocationsTab = "//div[text()='Sublocations']";
    this.addNewSublocation = "//fab-button/a/span[text()='Add New']";
    //endregion


    //region users

    this.newUserSpan = "//button[@id='btn-add-user']";
    this.userNameFieldXpath = "//input[@name='name']";
    this.userSurnameFieldXpath = "//input[@name='surname']";
    this.userTypeDropdown = "//div[@class='mat-select-value']";
    this.userTypeAdmin = "//span[text()=' Admin ']";
    this.userEmailFieldXpath = "//input[@name='email']";
    this.userCreationNextStepButton = "//flat-button/button/span[text()='Next']";
    this.userCreationDoneButton = "//flat-button/button/span[text()='Done']";
    this.createdUser = "//div/a[text()='"+ this.userName +" "+ this.changedUserName+" "+ this.userSurName +" "+ this.changedUserSurName+"']";
    this.createdUser1 = "//div/a[text()='"+ this.userName +" "+ this.userSurName +"']";
    this.UsersButton = "//a/span[text() = 'Users']";
    this.changedUserFirstNameFieldXpath = "//input[@formcontrolname = 'firstName']";
    this.changedUserLastNameFieldXpath = "//input[@formcontrolname = 'lastName']";
    this.changedUserSaveButton = "//flat-button/button/span[text()=' Save ']";
    this.deleteUserButton = "//flat-button/button/span[text()='Delete user']";
    this.confirmDeleteUserButton = "//flat-button/button/span[text()='Delete']";
    this.viewUsersButton = "//flat-button/button/span[text()='View users']";
    //endregion



    //region Stripe

    this.clientsIcon = "//app-icon[@iconname='icon-single-user']";
    this.clientsIcon2 = "//div[@class='user-info center-both']/app-icon";
    this.paymentTab = "//div[text()='Payment']";
    this.stripeTab = "//div[text()='Stripe']";
    this.connectWithStripeButton = "//flat-button/button/span[text()='Connect with Stripe']";
    this.skipRegisterForm = "//a[@id='skip-account-app']";
    //endregion
  }



}
