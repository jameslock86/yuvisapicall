# yuvisapicall


Yep, got them right here for you

credentials for api call 

nyc070     admin    iA1wS46zi10Y
nyc070     user0    s1uqUKZFjDlu
nyc070     user1    yjhSX3ueUu58
nyc070     user2    pcvs6rfLDv76
nyc070     user3    o4VzZZlBCtak
nyc070     user4    ctHQcUBovEDu

https://app.swaggerhub.com/apis-docs/osroot/yuuvis/1.0

yuuvis
 1.0 
OAS3
Welcome to the yuuvis API Documentation
This API provides the basic document management functionality for the redline hackathon. With the yuuvis API you can easily connect a document management system to a web application or a mobile app. This documentation will help you integrate the API into your application and is intended for developers.

Authorize to Use the API
You must be authorized to use the API. For this you should have username, password, and tenant values. If you don't have those values, please contact justin@bemyapp.com.

Once you have these values simply click on the Authorize button below and fill in the two available authorizations. For the first authorization, you need to enter your username and password and click Authorize. In the second dialog, enter your tenant and click Authorize.

Getting Started
To get a quick start in using the API, you can use the following metadata example to store any file in the document management system.
Uploading a Document Step-By-Step
Save the following metadata as a file called metadata.json 
{
"objects": [{
"properties": {
"enaio:objectTypeId": {
"value": "document"
},
"Name": {
"value": "my document"
}
},
"contentStreams": [{
"cid": "cid_63apple"
}]
}]
}
Expand the call for storing documents below (/dms/objects) and click Try it out. You must choose two files for the multipart request. For the data part, select your metadata.json file. For the cid_63apple part, select the file you want to upload. Finally, click Execute and you're done.

Hint: Make sure you are authorized!
Any Questions?
Join Slack and visit the #tech-support channel!