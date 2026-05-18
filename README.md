## 🚀 Инструкция по локальному запуску

Запуск через Docker Compose
1. **Открыть терминал** в корневой папке проекта.
2. **Выполнить сборку** Docker-образов:

   ```bash
   docker-compose build --no-cache
   ```



3. **Запустить контейнеры** в фоновом режиме:

```bash
docker-compose up -d
```


4. **Открыть приложение** в браузере по адресу: **http://localhost:8080**



## 🛠 Команды управления проектом (Для разработки)

* **Восстановление зависимостей:**

```bash
dotnet restore

```


* **Сборка решения:**

```bash
dotnet build

```


* **Добавление новой миграции:**

```bash
dotnet ef migrations add ИМЯ_МИГРАЦИИ --project src/WomenClothingStore.Infrastructure --startup-project src/WomenClothingStore.Web
```



```

```
