**JWT KEY**

```bash
dotnet user-secrets
dotnet user-secrets list
dotnet user-secrets set "Jwt:Key" 8b7f3d19c2e54a06f91d8e7b4c30a5f2d6e9c18b74a03f5d2e6b9c71a48f0d35"
```

**erlaubter Origin**

```bash
curl -i -X OPTIONS http://localhost:5080/posts \
  -H "Origin: http://localhost:5173" \
  -H "Access-Control-Request-Method: POST" \
  -H "Access-Control-Request-Headers: authorization,content-type"
```

**nicht erlaubter Origin**

```bash
curl -i -X OPTIONS http://localhost:5080/posts -H "Origin: http://example.com" -H "Access-Control-Request-Method: POST"
```
