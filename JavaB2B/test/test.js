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
const admintoken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSIsImtpZCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSJ9.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmJldGEuanVpY2UubmV0L2lkZW50aXR5IiwiYXVkIjoiaHR0cHM6Ly9hY2NvdW50cy5iZXRhLmp1aWNlLm5ldC9pZGVudGl0eS9yZXNvdXJjZXMiLCJleHAiOjE1ODg0MTY5MjQsIm5iZiI6MTU4NTgyNDkyNCwiY2xpZW50X2lkIjoiYjJiLnVpIiwic2NvcGUiOlsib3BlbmlkIiwicHJvZmlsZSIsInJvbGVzIiwiYXBpIl0sInN1YiI6IjRmYmEwYjZjLTA2ZjktNDkzOS1iMTI2LTFhYjQ3N2IxNWUxNiIsImF1dGhfdGltZSI6MTU4NTgyNDkyNCwiaWRwIjoiaWRzcnYiLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJhZG1pbkBlbW90b3J3ZXJrcy5jb20iLCJlbWFpbCI6ImFkbWluQGVtb3RvcndlcmtzLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjoidHJ1ZSIsInJvbGUiOlsiQWRtaW5zIiwiQ2FyIEFkbWluIiwiRGlyZWN0b3J5QWRtaW5zIiwiRW5lcmd5R3JvdXAgQWRtaW4iLCJTdXBlciBBZG1pbnMiXSwiZ2l2ZW5fbmFtZSI6ImFkbWluQGVtb3RvcndlcmtzLmNvbSIsImZhbWlseV9uYW1lIjoibm90IHN1cHBvcnRlZCIsImFtciI6WyJwYXNzd29yZCJdfQ.NOmdZXyJgWuH9lmr8su_NCMWV0Un7o6RwtGvvaa6lHktOR89pvsNhddur2P-hQvZuz9afLsq2sxDlXW6fGAMSJ6rCVOnKQINARp1G1ltLxiQA5zp-QkJn6zPjkYyKJzscl6O93q-TJ3k8p3quUiKsmZI54ryg_dOIMuVZHNNwoPpfm764xWL-3U4dSJnmMgD4SlhaH2NjrdxFppYbxqMfCcR3XNwQ5zHVjn3TOK__1NTa8_anoEbGioCODW1LtrDn5u7R0hc-Xb-kwPmt_JTfdAErui3QULLPnz_ZtTTD3bS_Q9rRw-9ChAHE5g9bYcI75rJTCSy5CR6dx2pc7erpw"

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
                    'endpointId': 7,
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
                        "pluggedIn": false
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
  },40000);

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
    await util.findAndType(driver, page.ratePerSessionField, "12");
    await util.findAndType(driver, page.ratePerHour, "12");
    await util.findAndType(driver, page.ratePerSession, "12");
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
      await driver.wait(sleep(2000), 4000);
    await util.findElementWithXpath(driver, page.deleteGroupButton);
    await util.findByXpathAndClick(driver, page.deleteGroupButton);
    await util.findByXpathAndClick(driver, page.confirmDeleteButton);
    await done();
  }, 50000);
  test('location test', async (done) => {
      try {
  await driver.wait(sleep(2000), 4000);
  await util.findByXpathAndClick(driver, page.locationsMenuOption);
  await util.findByXpathAndClick(driver, page.globalAddButtonXpath);
  await driver.wait(sleep(3000), 4000);
  await util.findByXpathAndClick(driver, page.newLocationSpan);
  await util.findAndType(driver, page.locationNameFieldXpath, page.locationName);
  await driver.wait(sleep(3000), 4000);
  await util.findByXpathAndClick(driver, page.locationCreateNextButton);
  await driver.wait(sleep(3000), 4000);
  await util.findByXpathAndClick(driver, page.locationCreateDoneButton);
  await driver.wait(sleep(3000), 4000);
  await util.findByXpathAndClick(driver, page.viewLocationsButton);
  await done();
  }
catch (e) {
        await console.log(e);
        done(error);
    }
  });

    test('sublocation test', async (done) => {
        try {
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
            await util.findByXpathAndClick(driver, page.selectRateDropdown);
            await util.findByXpathAndClick(driver, page.specificRateValue);
            await util.findByXpathAndClick(driver, page.dcSettingsTab);
            await driver.wait(sleep(3000), 4000);
            await util.findAndType(driver, page.maxPowerDCField, "25");
            await util.findByXpathAndClick(driver, page.allowPublicAccessSwitch);
            await util.findByXpathAndClick(driver, page.sublocationCreateDoneButton);
            await driver.wait(sleep(3000), 4000);
            await util.findByXpathAndClick(driver, page.viewLocationsButton);
            await done();
        }
        catch (e) {
            await console.log(e);
            done(error);
        }
        /*const SelectParentLocation = await util.findElementWithXpath(driver, page.SelectParentLocation);
      SelectParentLocation.selectedIndex = 0;*/
    }, 50000);

  test('RFID add from admin side', async (done) => {

          Request.post({
              'headers': { 'content-type': 'application/json' ,
                  'Authorization' : 'Bearer ' + admintoken},
              'url': 'https://admin-api.beta.juice.net/api/v1/rfid-registry',
              'body': JSON.stringify(
                  [{"RFID":page.rfid,"SerialNumber":page.rfidSerialNumber}]
              )
          }, function (error, response, body)  {
              console.log('\n\n*RFID CREATED*');
              done();
          });
      });
    test('RFID add from reseller side', async (done) => {
        try {
        await util.findByXpathAndClick(driver, page.globalAddButtonXpath);
        await util.findByXpathAndClick(driver, page.addRfidButtonSpan);
        await util.findAndType(driver, page.cardID, page.rfidSerialNumber);
        await driver.wait(sleep(3000), 4000);
        await util.findByXpathAndClick(driver, page.cardCreateDoneButton);
        await driver.wait(sleep(3000), 4000);
        await util.findByXpathAndClick(driver,page.createdRfidCard);
        done();
    }
catch (e) {
        await console.log(e);
        done(error);
    }

    });
test("plug the emulator device", async (done) =>{
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
  test('Add cloud device', async (done) => {
      try {
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
    await util.findByXpathAndClick(driver, page.selectRateDropdown);
    await util.findByXpathAndClick(driver, page.specificRateValue);
    await driver.wait(sleep(2000), 4000);
    await util.findByXpathAndClick(driver, page.addDeviceDoneButton);
    await driver.wait(sleep(2000), 4000);
    await util.findByXpathAndClick(driver, page.viewDevicesButton);
    await util.findByXpathAndClick(driver, "//a[text()='Autotest device "+templateID+"']");
    done();
  }
catch (e) {
        await console.log(e);
        done(error);
    }
  }, 50000);
    test('Device interactions', async (done) => {
try {
        await util.findByXpathAndClick(driver, page.startChargingButton);
        await driver.wait(sleep(2000), 4000);
        await util.findByXpathAndClick(driver, page.historyTab);
        await driver.wait(sleep(1000), 4000);
        await util.findElementWithXpath(driver, page.inUsediv);
        await driver.wait(sleep(5000), 6000);
        await util.findByXpathAndClick(driver, page.stopChargingButton);
        done();
    }
catch (e) {
        await console.log(e);
        done(error);
    }
    },50000);
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