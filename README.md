# ShopBridgeApi
## Databse used
Mysql server 8.0.26

1. ## List Of all items
URI = /api/Item
Method = get

2. ## Get item by id
URI = /api/Item/{id}
Method = get

3. ## Insert an item
URI = /api/Item
Method = post
content = {"id": 0,//Auto generated
    "name": "string",// Length can't be less then 3 character.
    "price": 0,
    "discription": "string",//Maximum length 150
    "imageUrl": "string"}
    
4. ## Update an item
URI = /api/Item
Method = put
content = {"id": 0,//Auto generated
    "name": "string",// Length can't be less then 3 character.
    "price": 0,
    "discription": "string",//Maximum length 150
    "imageUrl": "string"}
    
5. ## Delete item by id
URI = /api/Item/{id}
Method = delete
