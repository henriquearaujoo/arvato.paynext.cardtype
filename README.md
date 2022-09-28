﻿# arvato.paynext.cardtype

# REST API application

This is an asp.net core web api application to validate credit card data and return the card type based on data.

## Get credit card type

### Request

`POST /type`

    curl -X 'POST' \
      'https://localhost:7005/api/CreditCard/type' \
      -H 'accept: application/json' \
      -H 'Content-Type: application/json' \
      -d '{
      "owner": "VICTOR G MUNIZ",
      "number": "4485091335938218",
      "issueDate": "01/2024",
      "cvc": "805"
    }'

### Response

    content-type: application/json; charset=utf-8 
    date: Tue,27 Sep 2022 20:35:55 GMT 
    server: Kestrel 

    {
      "cardType": "Visa"
    }
