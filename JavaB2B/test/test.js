import {Builder, By, error, Key} from 'selenium-webdriver';
import webdriver from 'selenium-webdriver';
import SignInPage from './testSetup';
import * as util from './utils';


const sleep = (milliseconds) => {
  return new Promise(resolve => setTimeout(resolve, milliseconds))
};
const today = new Date();
const clientName = "client autotest"  + today;
const userEmail = "6dofik+c" + today.getDay() + today.getHours() +  today.getMinutes() +  "betaautotest@gmail.com";
const clientEmail = "parkhval+c" + today.getDay() + today.getHours() +  today.getMinutes() +  "betaautotest@gmail.com";

describe('Reseller, main actions', () => {
  let driver;
  let page;
  jest.setTimeout(30000);
  beforeAll(async () => {
    driver = new webdriver.Builder().forBrowser("chrome").build();
    driver.manage().window().maximize();
    driver.manage().setTimeouts({
      implicit: 10000, pageLoad:
        10000, script: 10000
    });
    page = new SignInPage();
  }, 20000);
  afterAll(async () => {
   // await driver.quit();
  });
  test('Login as reseller', async () => {
    await util.login(driver, page.loginUrl, page.resellerEmail, page.resellerPassword);
    // await util.findByXpathAndClick(driver, "//div/a[text() = ' Login as Client ']");
  }, 30000);

  test('Create a new client for a current reseller', async () => {
    await util.findByXpathAndClick(driver, page.createNewClientButtonXpath);
    await util.findAndType(driver, page.nameFieldXpath, clientName);
    await util.findAndType(driver, page.emailFieldXpath, clientEmail);
    await util.findAndType(driver, page.adminFirstName, "Admin first name");
    await util.findAndType(driver, page.adminLastName, "Admin last name");
    await util.findByXpathAndClick(driver, page.currency);
    await util.findByXpathAndClick(driver, page.dollarSpanXpath);
    await util.findAndType(driver, page.address, 'emotorwerks autotest str 54a');
    await util.findAndType(driver, page.city, 'Zaporizhzhia');
    await util.findAndType(driver, page.state, 'Zaporizhzhya');
    await util.findAndType(driver, page.zipCode, '69005');
    const timezone = await util.findElementWithXpath(driver, page.timeZone);
    timezone.selectedIndex = 19;
    //  await driver.wait(sleep(3000), 4000);
    await util.findByXpathAndClick(driver, page.createButton);
    await driver.wait(sleep(5000), 5000);
    await util.findElementWithXpath(driver, page.viewClientsButton);
    await util.findByXpathAndClick(driver, page.viewClientsButton);
    await util.findByXpathAndClick(driver, page.sortButton);
    await util.findByXpathAndClick(driver, page.sortButton);
    const createdclient = await util.findElementWithXpath(driver, "//datatable-scroller/datatable-row-wrapper/datatable-body-row/div/datatable-body-cell  /div/a[text()='" + clientName + "']/../../../datatable-body-cell/div/a[text() = ' Login as Client ']")
    await createdclient.click();
  });
  test('Create a new rate', async () => {
    await util.findByXpathAndClick(driver, page.ratesMenuOption);
    await util.findByXpathAndClick(driver, page.globalAddButtonXpath);
    await driver.wait(sleep(3000), 4000);
    await util.findByXpathAndClick(driver, page.newRateSpan);
    await util.findAndType(driver, page.rateName, page.rateNameString);
    await util.findByXpathAndClick(driver, page.saveRateButton);
    await util.findByXpathAndClick(driver, page.createdRateXpath);
    await util.findAndType(driver, page.editRateName, page.rateNameString + "edited");
    await util.findByXpathAndClick(driver, page.saveOnEditButton);
    await driver.wait(sleep(3000), 4000);
    await util.findByXpathAndClick(driver, page.alertOkButton);
  });
  test('Create a new group', async (done) => {
    await util.findByXpathAndClick(driver, page.groupsMenuOption);
    await util.findByXpathAndClick(driver, page.globalAddButtonXpath);
    await driver.wait(sleep(3000), 4000);
    await util.findByXpathAndClick(driver, page.newGroupSpan);
    await util.findAndType(driver, page.groupNameInput, "Autotest user group");
    await util.findByXpathAndClick(driver, page.groupCreationNextStepButton);
    await util.findByXpathAndClick(driver, page.groupCreationDoneButton);
    await util.findByXpathAndClick(driver, page.createdGroup);
    await util.findAndType(driver, page.editGroupNameField, "Autotest Edit name");
    await util.findByXpathAndClick(driver, page.saveEditedGroupName);
    await util.findByXpathAndClick(driver, page.usersTabOfGroups);
    await driver.wait(sleep(3000), 4000);
    await util.findByXpathAndClick(driver, page.assignNewUSerButton);
    await util.findAndType(driver, page.userSearchInput, "Admin");
    await driver.wait(sleep(3000), 4000);
    await util.findByXpathAndClick(driver, page.searchUserButton);
    await util.findByXpathAndClick(driver, page.selectUserCheckbox);
    await util.findByXpathAndClick(driver, page.saveUserSearchButton);
    await util.findElementWithXpath(driver, page.deleteGroupButton);
    await util.findByXpathAndClick(driver, page.deleteGroupButton);
    await util.findByXpathAndClick(driver, page.confirmDeleteButton);
    await done();
  }, 50000);
  test('location test', async (done) => {

  await util.findByXpathAndClick(driver, page.locationsMenuOption);
  await util.findByXpathAndClick(driver, page.globalAddButtonXpath);
  await driver.wait(sleep(3000), 4000);
  await util.findByXpathAndClick(driver, page.newLocationSpan);
  await util.findAndType(driver, page.locationNameFieldXpath, page.locationName);
  await driver.wait(sleep(3000), 4000);
  await util.findByXpathAndClick(driver, page.locationCreateNextButton);
  await util.findByXpathAndClick(driver, page.locationCreateDoneButton);
  await driver.wait(sleep(3000), 4000);
  await util.findByXpathAndClick(driver, page.viewLocationsButton);
/*  await util.findByXpathAndClick(driver, page.createdLocationInTable);
  await util.findByXpathAndClick(driver, page.sublocationsTab);
  await util.findByXpathAndClick(driver, page.addNewSublocation);
  await util.findAndType(driver, page.locationNameFieldXpath, "Sublocation name asdasdasdas dasd asd asd asd asd");
  await driver.wait(sleep(1000), 4000);
  await util.findByXpathAndClick(driver, page.locationCreateNextButton);
  await util.findByXpathAndClick(driver, page.locationCreateDoneButton);
  await driver.wait(sleep(3000), 4000);
  await util.findByXpathAndClick(driver, page.viewLocationsButton);*/
  await done();
  }, 50000);
 });


describe('Client, main actions', () => {
  let driver;
  let page;
  jest.setTimeout(30000);
  beforeAll(async () => {
    driver = new webdriver.Builder().forBrowser("chrome").build();
    driver.manage().window().maximize();
    driver.manage().setTimeouts({
      implicit: 10000, pageLoad:
          10000, script: 10000
    });
    page = new SignInPage();
  }, 20000);
  afterAll(async () => {
  // await driver.quit();
  });


test('Login as client', async (done) => {
  try {

    await util.login(driver, page.loginUrl, page.clientEmail, page.clientPassword);
  }catch
  {
    driver.refresh();
    await util.login(driver, page.loginUrl, page.clientEmail, page.clientPassword);
  }
   await done();
},40000);

test('create new user', async (done) => {
  await util.findByXpathAndClick(driver, page.globalAddButtonXpath);
  await driver.wait(sleep(2000), 3000);
  await util.findByXpathAndClick(driver, page.newUserSpan);
  await util.findAndType(driver, page.userNameFieldXpath, page.userName);
  await util.findAndType(driver, page.userSurnameFieldXpath, page.userSurName);
  await util.findByXpathAndClick(driver, page.userTypeDropdown);
  await util.findByXpathAndClick(driver, page.userTypeAdmin);
  await util.findAndType(driver, page.userEmailFieldXpath, userEmail);
  await util.findByXpathAndClick(driver,page.userCreationNextStepButton);
  await util.findByXpathAndClick(driver, page.userCreationDoneButton);
  await util.findByXpathAndClick(driver, page.createdUserBeforeUpdate);
  await done();
});

test('change user information', async (done) => {
  try {


    await util.findByXpathAndClick(driver, page.UsersButton);
    console.log(page.createdUserBeforeUpdate);
    await util.findByXpathAndClick(driver, page.createdUserBeforeUpdate);
    await util.findAndType(driver, page.changedUserFirstNameFieldXpath, page.changedUserName);
    await util.findAndType(driver, page.changedUserLastNameFieldXpath, page.changedUserSurName);
    await util.findByXpathAndClick(driver, page.changedUserSaveButton);
    await driver.wait(sleep(2000), 3000);
    await done();
  }
  catch (error) {console.log(error)}
});

test ('delete user', async (done) => {
  await util.findByXpathAndClick(driver, page.UsersButton);
  console.log (page.createdUser);
  await util.findByXpathAndClick(driver, page.createdUser);
  await driver.wait(sleep(2000), 3000);
  await util.findByXpathAndClick(driver, page.deleteUserButton);
  await driver.wait(sleep(1000), 3000);
  await util.findByXpathAndClick(driver, page.confirmDeleteUserButton);
  await util.findByXpathAndClick(driver, page.viewUsersButton);
  await done();
});

/*test('connect with stripe', async (done) => {
  await driver.wait(sleep(2000), 3000);
  await util.findByXpathAndClick(driver, page.clientsIcon);
  await driver.wait(sleep(2000), 3000);
  await util.findByXpathAndClick(driver, page.clientsIcon2);
  await util.findByXpathAndClick(driver, page.paymentTab);
  await util.findByXpathAndClick(driver, page.stripeTab, );
  await driver.wait(sleep(2000), 3000);
  await util.findByXpathAndClick(driver, page.connectWithStripeButton);
  await util.findElementWithXpath(driver, page.skipRegisterForm);
  await done();
});*/
});
