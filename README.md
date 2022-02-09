API CONTROLE FINANCEIRO


URL: https://controlefinanceiroaluraapi.azure-api.net

ENDPOINTS

#AUTH
POST https://controlefinanceiroaluraapi.azure-api.net/api/v1/account/login HTTP/1.1
Content-Type: application/json
{"id":0,"username":"string","password":"string","role":"string"}

#RESUMO
GET https://controlefinanceiroaluraapi.azure-api.net/api/Resumo/{ano}/{mes} HTTP/1.1
Authorization: Bearer TOKEN

#DESPESAS
POST https://controlefinanceiroaluraapi.azure-api.net/api/Despesas HTTP/1.1
Authorization: Bearer TOKEN
{"id":0,"description":"string","value":0,"date":"2022-02-08","categoria":0}

GET https://controlefinanceiroaluraapi.azure-api.net/api/Despesas HTTP/1.1
 Authorization: Bearer TOKEN
  
GET https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/{ano}/{mes} HTTP/1.1
Authorization: Bearer TOKEN
  
DELETE https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/{id} HTTP/1.1
Authorization: Bearer TOKEN

GET https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/1 HTTP/1.1
Authorization: Bearer TOKEN

PUT https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/{id} HTTP/1.1
Content-Type: application/json
{"id":0,"description":"string","value":0,"date":"2022-02-08","categoria":0}

GET https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/descricao?descricao={descrição} HTTP/1.1
Authorization: Bearer TOKEN

#RECEITAS

POST https://controlefinanceiroaluraapi.azure-api.net/api/Receitas HTTP/1.1
Authorization: Bearer TOKEN
{"id":0,"description":"string","value":0,"date":"2022-02-08"}

GET https://controlefinanceiroaluraapi.azure-api.net/api/Receitas HTTP/1.1
 Authorization: Bearer TOKEN
  
GET https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/{ano}/{mes} HTTP/1.1
Authorization: Bearer TOKEN
  
DELETE https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/{id} HTTP/1.1
Authorization: Bearer TOKEN

GET https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/1 HTTP/1.1
Authorization: Bearer TOKEN

PUT https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/{id} HTTP/1.1
Content-Type: application/json
{"id":0,"description":"string","value":0,"date":"2022-02-08"}

GET https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/descricao?descricao={descrição} HTTP/1.1
Authorization: Bearer TOKEN






