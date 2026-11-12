### Test streaming with Curl:

```bash
curl -N -X POST http://localhost:3000/claude/stream \
  -H "Content-Type: application/json" \
  -d '{"prompt":"Explain HTTP caching in three sentences."}'
```
