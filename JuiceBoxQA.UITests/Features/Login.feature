Feature: Login
    In order to access restricted site options
    As a registered JuiceNet user
    I want to be able to log in

@browser
Scenario Outline: Login using valid credentials
    Given I have a registered user <firstname> with username <username> and password <password>
    And he is on the JuiceNet login page
    When he logs in using his credentials
    Then he should land on the Accounts Overview page

    Examples:
    | firstname | username                      | password   |
    | Alex      | alexander.burdeyniy@gmail.com | Rjcvjc2020 |
    | Bob       | alexander.burdeyniy@gmail.com | demo       |
    
@browser
Scenario:  Login using incorrect password
    Given I have a registered user Alex with username alexander.burdeyniy@gmail.com and password Rjcvjc2020
    And he is on the JuiceNet login page
    When he logs in using an invalid password
    Then he should see an error message stating that the login request was denied
