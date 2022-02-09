# API CONTROLE FINANCEIRO


##### **URL**: https://controlefinanceiroaluraapi.azure-api.net

#
**AUTH**
###
**POST** https://controlefinanceiroaluraapi.azure-api.net/api/v1/account/login HTTP/1.1 \
Content-Type: application/json \
body{"username":"admin","password":"admin","role":"manager"}
#
**RESUMO**
###
**GET** https://controlefinanceiroaluraapi.azure-api.net/api/Resumo/{ano}/{mes} HTTP/1.1 \
Authorization: Bearer Token
#
**DESPESAS**

**POST** https://controlefinanceiroaluraapi.azure-api.net/api/Despesas HTTP/1.1 \
Authorization: Bearer Token \
body{"id":0,"description":"string","value":0,"date":"2019-01-06T17:16:40","categoria":0}

**GET** https://controlefinanceiroaluraapi.azure-api.net/api/Despesas HTTP/1.1 \
 Authorization: Bearer Token

**GET** https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/{ano}/{mes} HTTP/1.1 \
Authorization: Bearer Token
  
**DELETE** https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/{id} HTTP/1.1 \
Authorization: Bearer Token

**GET** https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/1 HTTP/1.1 \
Authorization: Bearer Token

**PUT** https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/{id} HTTP/1.1 \
Content-Type: application/json \
{"id":0,"description":"string","value":0,"date":"2019-01-06T17:16:40","categoria":0}

**GET** https://controlefinanceiroaluraapi.azure-api.net/api/Despesas/descricao?descricao={descrição} HTTP/1.1 \
Authorization: Bearer Token

#
**RECEITAS**

**POST** https://controlefinanceiroaluraapi.azure-api.net/api/Receitas HTTP/1.1 \
Authorization: Bearer Token \
{"id":0,"description":"string","value":0,"date":"2019-01-06T17:16:40"}

**GET** https://controlefinanceiroaluraapi.azure-api.net/api/Receitas HTTP/1.1 \
 Authorization: Bearer Token
  
**GET** https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/{ano}/{mes} HTTP/1.1 \
Authorization: Bearer Token
  
**DELETE** https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/{id} HTTP/1.1 \
Authorization: Bearer Token

**GET** https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/1 HTTP/1.1 \
Authorization: Bearer Token

**PUT** https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/{id} HTTP/1.1 \
Content-Type: application/json
{"id":0,"description":"string","value":0,"date":"2019-01-06T17:16:40"}

**GET** https://controlefinanceiroaluraapi.azure-api.net/api/Receitas/descricao?descricao={descrição} HTTP/1.1 \
Authorization: Bearer Token






