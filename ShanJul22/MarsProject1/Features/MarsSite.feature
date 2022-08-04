Feature: A User is able to login to the MarsSite, share a skill, search for a skill and contact provider.

The tests below test user login, create a listing to share,
                search for a skill on the search and contact provider and
				Review Requests Sent and Action.
	
Scenario Outline: [A user can search for a example skill and contact a example Provider ]
	Given [User is logged into website.]
	When  [User enters '<Skill>' in search button and press Enter. ]
	Then  [User can verify if user '<Provider>' exists and send a request to provider.]
	Then  [User can SignOut of portal.]

	Examples:
	        | Skill             | Provider          |
	        | My Programming566 | Abcdabcd Abcdabcd |
	        | <skill            | Abcdabcd Abcdabcd |
	        
	        

Scenario: [A User can enter invalid data in the Share Skill form, receive the correct error messages, enter valid data and share the listing]

	Given [User is logged into website.]
	When  [User clicks on ShareSkill, user can navigate to ShareSkill Form]
	Then  [User can Enter invalid Data, Title, Description, StartDate and Receive Error Messages, Correct Form with correct CTitle,CDescription,CStartDate and Save Listing]
	Then  [User can SignOut of portal.]


Scenario Outline:[Check User Login with incorrect input]

	Given [User has launched website]
	Then  [User can enter '<UserName>' and '<Password>' and login to portal]
	Then  [User can SignOut of portal.]

	Examples: 
			| UserName          | Password |
			| abcd@abcd.com     | abc      |
			| abcabcd           | abcabc   |
			| mylogin@email     | abcabc   |

Scenario: [User can goto Sent Requests and Action Reqests Sent.]
	
	Given [User is logged into website.]
	When  [User clicks on Manage Requests menu option and goes to Sent Requests option.]
	Then  [User can review requests sent and action, provide a review and withdraw request.]
	Then  [User can SignOut of portal.]

