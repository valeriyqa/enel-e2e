import {By, until, wait} from "selenium-webdriver";
import SignInPage from "./testSetup";

let page  = new SignInPage();

const sleep = (milliseconds) => {
  return new Promise(resolve => setTimeout(resolve, milliseconds))
}

export async function findElementWithID (driver, id, timeout = 20000) {
  const el = await driver.wait(until.elementLocated(By.id(id)), timeout);
  return await driver.wait(until.elementIsVisible(el), timeout);
}
 export async function findElementWithName (driver, name, timeout = 20000) {
  const el = await driver.wait(until.elementLocated(By.name(name)), timeout);
  return await driver.wait(until.elementIsVisible(el), timeout);
}
 export async function findElementWithXpath(driver, xpath,  timeout = 20000) {
  const el = await driver.wait(until.elementLocated(By.xpath(xpath)), timeout)
  return await driver.wait(until.elementIsVisible(el), timeout)
}
 export async  function checkIfDisplayed(driver, xpath, timeout = 20000){
  const el = driver.findElement(By.xpath(page.labelsField)).isDisplayed();
  return el;
}

export async function login(driver, loginUrl, login, password, timeout = 20000)
{
  await driver.get(loginUrl);
  const emailInput = await driver.findElement(By.id(page.emailFieldID));
  const passwordInput = await driver.findElement(By.id(page.passwordFieldID));
  const loginButton = await driver.findElement(By.id(page.submitLoginButtonXpath));
  await emailInput.sendKeys(login);
  await passwordInput.sendKeys(password);
  await loginButton.click();
  await driver.wait(sleep(3000), 4000);
  // let expected = await driver.getCurrentUrl();
}


export async function findByXpathAndClick(driver, xpath,  timeout = 20000) {
    const el = await driver.wait(until.elementLocated(By.xpath(xpath)), timeout);
    await driver.findElement(By.xpath(xpath)).click();
}

export async function findAndType(driver, xpath, text, timeout = 2000){
    const el = await driver.wait(until.elementLocated(By.xpath(xpath)), timeout);
    await driver.findElement(By.xpath(xpath)).sendKeys(text);
}
