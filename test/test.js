import {Builder, By, error, Key, until} from 'selenium-webdriver';
import webdriver from 'selenium-webdriver';
import SignInPage from './testSetup';
import * as util from './utils';


const sleep = (milliseconds) => {
  return new Promise(resolve => setTimeout(resolve, milliseconds))
}
const today = new Date();
const clientName = "client autotest"  + today;
const clientEmail = "parkhval+c" + today.getDay() + today.getHours() +  today.getMinutes() +  "betaautotest@gmail.com";
describe('Reward moderator, rewards validation checks', () => {
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
  test('Login as reward admin', async () => {
    await util.login(driver, page.loginUrl, page.resellerEmail, page.resellerPassword);
  });
  test('Create a new client for a current reseller', async () => {
    const newClientButton = await util.findElementWithXpath(driver, page.createNewClientButtonXpath);
    await newClientButton.click();
    //region new Client form locators finding
    const nameField = await util.findElementWithXpath(driver, page.nameFieldXpath);
    const emailField =  await util.findElementWithXpath(driver, page.emailFieldXpath);
    const adminFirstName = await util.findElementWithXpath(driver, page.adminFirstName);
    const adminLastName = await util.findElementWithXpath(driver, page.adminLastName);
    const currencyDropdown = await util.findElementWithXpath(driver, page.currency);

    const address = await util.findElementWithXpath(driver, page.address);
    const city = await util.findElementWithXpath(driver, page.city);
    const state = await util.findElementWithXpath(driver, page.state);
    const zipCode = await util.findElementWithXpath(driver, page.zipCode);
    const timezone = await util.findElementWithXpath(driver, page.timeZone);


    //endregion
    
    await nameField.sendKeys(clientName);
    await emailField.sendKeys(clientEmail);
    adminFirstName.sendKeys("Admin first name");
    await adminLastName.sendKeys("Admin last name");
    await currencyDropdown.click();
    const currencyValue = await util.findElementWithXpath(driver, page.dollarSpanXpath);
    await currencyValue.click();
    await address.sendKeys('emotorwerks street 54a');
    await city.sendKeys("Zaporizhzhia");
    await state.sendKeys("Zaporizhzhia");
    await zipCode.sendKeys("69005");
    timezone.selectedIndex = 19;
    const createButton = await util.findElementWithXpath(driver, page.createButton);//sendKeys("(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius");
    await createButton.click();
    const viewClientsButton = await util.findElementWithXpath(driver, page.viewClientsButton);
    await viewClientsButton.click();
    const createdclient = await util.findElementWithXpath(driver, "//datatable-scroller/datatable-row-wrapper/datatable-body-row/div/datatable-body-cell  /div/a[text()='" + clientName + "']")
    await createdclient.click();e
  });
});
