import {Builder, By, error, Key} from 'selenium-webdriver';
import webdriver from 'selenium-webdriver';
import SignInPage from './testSetup';
import * as util from './utils';
import 'request';


const sleep = (milliseconds) => {
  return new Promise(resolve => setTimeout(resolve, milliseconds))
};
let  token;
const fs = require('fs');
let Request = require('request');

const today = new Date();
let templateID;
const clientName = "client autotest"  + today;
const userEmail = "6dofik+c" + today.getDay() + today.getHours() +  today.getMinutes() +  "alfaautotest@gmail.com";
const clientEmail = "parkhval+c" + today.getDay() + today.getHours() +  today.getMinutes() +  "alfaautotest@gmail.com";
const deviceName = "Autotest device" + today.getDay() + today.getHours() +  today.getMinutes();
const admintoken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSIsImtpZCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSJ9.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmRldi5qdWljZS5uZXQvaWRlbnRpdHkiLCJhdWQiOiJodHRwczovL2FjY291bnRzLmRldi5qdWljZS5uZXQvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNTg4MjMxNzk1LCJuYmYiOjE1ODU2Mzk3OTUsImNsaWVudF9pZCI6ImIyYi51aSIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJyb2xlcyIsImFwaSJdLCJzdWIiOiI0ZmJhMGI2Yy0wNmY5LTQ5MzktYjEyNi0xYWI0NzdiMTVlMTYiLCJhdXRoX3RpbWUiOjE1ODU2Mzk3OTUsImlkcCI6Imlkc3J2IiwicHJlZmVycmVkX3VzZXJuYW1lIjoiYWRtaW5AZW1vdG9yd2Vya3MuY29tIiwiZW1haWwiOiJhZG1pbkBlbW90b3J3ZXJrcy5jb20iLCJlbWFpbF92ZXJpZmllZCI6InRydWUiLCJyb2xlIjpbIkFkbWlucyIsIkNhciBBZG1pbiIsIkRpcmVjdG9yeUFkbWlucyIsIkVuZXJneUdyb3VwIEFkbWluIiwiU3VwZXIgQWRtaW5zIl0sImdpdmVuX25hbWUiOiJhZG1pbkBlbW90b3J3ZXJrcy5jb20iLCJmYW1pbHlfbmFtZSI6Im5vdCBzdXBwb3J0ZWQiLCJhbXIiOlsicGFzc3dvcmQiXX0.JJVw9YJUnzaJ8LBIC__loYA9uZmzHOmVydyA-L3Geq2AxkfZ7sxFuIKIRDGcMV1QTZe9V82PhzKSv_Py_6g5EXZa32siH8hqiGyWKlXm1rdkUSXElMc-Fl_0xR67EQkwNuomvASQ6D8pmQBiL1P6tXeNjhpEoEgepwkrLN4JoEinui7TiADF0r2S2xZSaHPY7VqwrRg3Hgf1bdgq__DP0bJM0HFOZG1FNwpXxEdsel5TN6q-ZDZI_7V4np7PsI79WR0xhmXUR7IzsHKRgyrG_8kO3yU6X8CYB1VyghTb-efNJOMwynSYobJqR1i0T-_QpCfar_rrkuY6a6_4UpuDGg"

describe('Cloud emulator craete device', function()  {
  test('Get a cloud amulator token',  function (done) {
      Request.post({
        'headers': { 'content-type': 'application/json' },
        'url': 'https://emulator-api.beta.juice.net/api/v1/identity/token',
        'body': JSON.stringify({
          'login': 'ilya.chikalov@emotorwerks.com',
          'password': 'CloudEmulator-2020'
        })
      }, function (error, response, body)  {
        console.log('\n\n*LOGIN REQUEST*');
        const responseBody =  JSON.parse(response.body);
        console.log(responseBody);
        token = responseBody.data.access_token;
        //expect(response.status.toEqual(200));
          done();
       });
  });
    test('Create a new template',  function (done) {
             Request
            .post ({
                'headers': { 'content-type': 'application/json',
                'Authorization' : 'Bearer ' + token},
                'url': 'https://emulator-api.beta.juice.net/api/v1/templates',
                'body': JSON.stringify({

                    'title': deviceName,
                    'description': '',
                    'instanceCount': 1,
                    'endpointId': 11,
                    'capabilities': {
                        'batteryCapacityWh': 50000,
                        "numPhasesVehicle": 1,
                        "numPhasesEvcs": 1,
                        "currentUnitMax": 40,
                        "currentUnitGenerationMax": 40,
                        "offlineInitialCurrent": 0
                    },
                    "baseParameters": {
                        "batterySocPct": 0,
                        "voltage": 240,
                        "currentEvDraw": 40,
                        "temperature": 36,
                        "frequency": 50,
                        "eocThresholdPct": 80,
                        "wifiRssi": 99
                    }
                })

                },  function ( error, response, body) {
                        console.log('\n\n*CREATE A TEMPLATE REQUEST*');
                        //console.log(body);
                        const responseBody = JSON.parse(response.body);
                        templateID = responseBody.id;  //3737-BETA-id-0
                        console.log(templateID);
                        //expect(response.status.toEqual(200));
                        done();
                    });
           });
    test('Run a created  template',  function (done)  {

            Request
                .patch({
                    'headers': {
                        'content-type': 'application/json',
                        'Authorization': 'Bearer ' + token
                    },
                    'url': 'https://emulator-api.beta.juice.net/api/v1/templates/' + templateID,
                    'body': JSON.stringify({
                        "isRunning": true,
                        "pluggedIn": true
                    })
                });
            done();
    });
});
//region OCPP EMULATOR TEST SUITE
/*describe('OCPP Emulator create device', () => {
  let driver;
  let page;
  jest.setTimeout(50000);
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

  test('OCPP Emulator connect', async (done) => {
    await driver.get("https://ocpp-us-dev-connector-ui.azurewebsites.net/");
    await util.findAndType(driver, "//input[@name='Username']", "valeriy");
    await util.findAndType(driver, "//input[@name='Password']","12qw!@QW");
    await util.findByXpathAndClick(driver, "//button[@type='submit']");
    await driver.wait(sleep(2000), 5000);
    await util.findByXpathAndClick(driver, "//a[text()='Add Device']");
    await util.findAndType(driver, "//input[@id='create-device-modal-add-Vendor']", "valeriy");
    await util.findAndType(driver, "//input[@id='create-device-modal-add-ChargePointId']", page.chargepointId);
    await util.findByXpathAndClick(driver,  "//button[@id='ck-modal-update']");
    await driver.wait(sleep(4000), 5000);
    await driver.get("https://ocpp-us-dev-connector-ui.azurewebsites.net/chargepoint/valeriy/" + page.chargepointId);
    await driver.findElement(By.xpath("//select[@id='DeviceTypeId']")).sendKeys('Juice Pole');
    await driver.findElement(By.xpath("//select[@id='UDPEndPoint']")).sendKeys('Alfa emulator');
    await driver.findElement(By.xpath("//select[@id='UDPProtocol']")).sendKeys('v9  ');
    await util.findByXpathAndClick(driver, "//a[@href='/emulator']");
    await driver.wait(sleep(6000), 7000);
    await driver.get("https://ocpp-us-dev-connector-ui.azurewebsites.net/emulator");
    await util.findAndType(driver, "//input[@id='cp-wsAddress']", page.wssEmulatorUrl);
    await util.findByXpathAndClick(driver, "//input[@id='cp-connect']");
    await done();
    });
  });*/
//endregion
describe('Reseller, main actions', () => {
  let driver;
  let page;
  jest.setTimeout(40000);
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
  test('Login as reseller', async (done) => {
    await util.login(driver, page.loginUrl, page.resellerEmail, page.resellerPassword);
    await util.findByXpathAndClick(driver, page.sortButton);
    await util.findByXpathAndClick(driver, "//div/a[text() = ' Login as Client ']");
    await driver.wait(sleep(4000), 5000);
    done();
  });

  /*test('Create a new client for a current reseller', async () => {
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
    await util.findElementWithXpath(driver, page.matDialogContainer)
    await util.findElementWithXpath(driver, page.viewClientsButton);
    await util.findByXpathAndClick(driver, page.viewClientsButton);
    await util.findByXpathAndClick(driver, page.sortButton);
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
    await util.findAndType(driver, page.editRateName, "edited");
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
    await util.findAndType(driver, page.userSearchInput, "parkh");
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
  await driver.wait(sleep(2000), 4000);
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
  });

    test('sublocation test', async (done) => {
        await util.findByXpathAndClick(driver, page.createdLocationInTable);
        await util.findByXpathAndClick(driver, page.sublocationsTab);
        await util.findByXpathAndClick(driver, page.addLocationButton);
        await util.findAndType(driver, page.sublocationNameFieldXpath, page.sublocationName);
        await driver.wait(sleep(2000), 4000);
        await util.findByXpathAndClick(driver, page.locationCreateNextButton);
        await util.findByXpathAndClick(driver, page.loadBalanceSwitch);
        await util.findAndType(driver, page.maxPowerField, "25");
        await util.findByXpathAndClick(driver, page.acSettingsTab);
        await util.findAndType(driver, page.maxPowerDCField, "25");
        await util.findByXpathAndClick(driver, page.allowPublicAccessSwitch);
        await util.findByXpathAndClick(driver,  page.selectRateDropdown);
        await util.findByXpathAndClick(driver, page.specificRateValue);
        await util.findByXpathAndClick(driver, page.dcSettingsTab);
        await driver.wait(sleep(3000), 4000);
        await util.findAndType(driver, page.maxPowerDCField, "25");
        await util.findByXpathAndClick(driver, page.allowPublicAccessSwitch);
            await util.findByXpathAndClick(driver, page.sublocationCreateDoneButton);
        await driver.wait(sleep(3000), 4000);
        await util.findByXpathAndClick(driver, page.viewLocationsButton);
        await done();
        /*const SelectParentLocation = await util.findElementWithXpath(driver, page.SelectParentLocation);
      SelectParentLocation.selectedIndex = 0;*/
    });

  test('RFID add from admin side', async (done) => {

          Request.post({
              'headers': { 'content-type': 'application/json' ,
                  'Authorization' : 'Bearer ' + admintoken},
              'url': 'https://admin-api.dev.juice.net/api/v1/rfid-registry',
              'body': JSON.stringify(
                  [{"RFID":page.rfid,"SerialNumber":page.rfidSerialNumber}]
              )
          }, function (error, response, body)  {
              console.log('\n\n*RFID CREATED*');
              done();
          });
      });
    test('RFID add from reseller side', async (done) => {
        await util.findByXpathAndClick(driver, page.globalAddButtonXpath);
        await util.findByXpathAndClick(driver, page.addRfidButtonSpan);
        await util.findAndType(driver, page.cardID, page.rfidSerialNumber);
        await util.findByXpathAndClick(driver, page.cardCreateDoneButton);
        await util.findByXpathAndClick(driver,page.createdRfidCard);
        done();
    });

  test('Add cloud device', async (done) => {
    await util.findByXpathAndClick(driver, page.globalAddButtonXpath);
    await driver.wait(sleep(2000), 4000);
    await util.findByXpathAndClick(driver, page.addDiviceButton);
    await util.findAndType(driver, page.deviceIdField, "3737-BETA-"+ templateID + "-0");
    await util.findAndType(driver, page.deviceNameField, "Autotest device " + templateID);
    await util.findByXpathAndClick(driver, page.locationSelect);
    await driver.wait(sleep(2000), 4000);
    await util.findByXpathAndClick(driver, "//mat-option/span[text()=' " + page.locationName + " ']");
    await driver.wait(sleep(5000), 6000);
    await util.findByXpathAndClick(driver, page.addDeviceNextStepButton);
    await util.findByXpathAndClick(driver, page.addDeviceDoneButton);
    await driver.wait(sleep(2000), 4000);
    await util.findByXpathAndClick(driver, page.viewDevicesButton);
    await util.findByXpathAndClick(driver, "//a[text()='Autotest device "+templateID+"']");
    done();
  });
});
/*describe('Client, main actions', () => {
  let driver;
  let page;
  jest.setTimeout(40000);
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
    await util.login(driver, page.loginUrl, page.clientEmail, page.clientPassword);
   await done();
});

/!*
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
*!/

/!*test('change user information', async (done) => {
  /!*driver.takeScreenshot().then(function(data){
    const base64Data = data.replace(/^data:image\/png;base64,/,"")
    fs.writeFile("out.png", base64Data, 'base64', function(err) {
      if(err) console.log(err);
    });
  });*!/
  await driver.wait(sleep(5000), 6000);
    //await util.findByXpathAndClick(driver, page.UsersButton);
    driver.get(page.loginUrl + "/users");
    await util.findByXpathAndClick(driver, page.createdUserBeforeUpdate);
    await util.findAndType(driver, page.changedUserFirstNameFieldXpath, page.changedUserName);
    await util.findAndType(driver, page.changedUserLastNameFieldXpath, page.changedUserSurName);
    await util.findByXpathAndClick(driver, page.changedUserSaveButton);
    await driver.wait(sleep(2000), 3000);
    await done();
  });

test ('delete user', async (done) => {
  driver.get(page.loginUrl + "/users");
  await util.findByXpathAndClick(driver, page.createdUser);
  await driver.wait(sleep(2000), 3000);
  await util.findByXpathAndClick(driver, page.deleteUserButton);
  await driver.wait(sleep(1000), 3000);
  await util.findByXpathAndClick(driver, page.confirmDeleteUserButton);
  await util.findByXpathAndClick(driver, page.viewUsersButton);
  await done();
});*!/

/!*test('connect with stripe', async (done) => {
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
});*!/
  test('RFID test client side', async (done) => {
    await driver.get(page.loginUrl + "/rfid");
    await util.findByXpathAndClick(driver, page.globalAddButtonXpath);
    await util.findByXpathAndClick(driver, page.addRfidButtonSpan);
    await util.findAndType(driver, page.cardID, page.cardIDString);
    await util.findByXpathAndClick(driver, page.cardCreateDoneButton);
    await util.findByXpathAndClick(driver, page.createdRfidCard);
    done();
  });
});*/