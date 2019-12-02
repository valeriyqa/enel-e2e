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
    await util.findByXpathAndClick(driver, "//div/a[text() = ' Login as Client ']");
  });
 /* test('Create a new client for a current reseller', async () => {
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
    await util.findByXpathAndClick(driver, page.createButton);
    await driver.wait(sleep(3000), 4000);
    await util.findByXpathAndClick(driver, page.viewClientsButton);
    await util.findByXpathAndClick(driver, page.sortButton);
    const createdclient = await util.findElementWithXpath(driver, "//datatable-scroller/datatable-row-wrapper/datatable-body-row/div/datatable-body-cell  /div/a[text()='" + clientName + "']/../../../datatable-body-cell/div/a[text() = ' Login as Client ']")
    await createdclient.click();
  });*/
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
});
