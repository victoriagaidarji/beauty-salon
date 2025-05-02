### Описание таблицы сущностей   

💆 **ProfessionalService** (Услуга)  
- `id` – Уникальный идентификатор  
- `name` – Название услуги  
- `description` – Описание  
- `duration` – Продолжительность (в минутах)  
- `price` – Базовая стоимость  
- `category` – Категория услуги (стрижка, маникюр и т. д.)  

✂️ **Master** (Мастер)  
- `id` – Уникальный идентификатор  
- `name` – Имя мастера  
- `specialization` – Специализация (парикмахер, косметолог и т. д.)  
- `experience` – Опыт (в годах)   
- `photo_url` – Фото мастера  

🔗 **Master_ProfessionalService** (Связь мастер-услуга)  
- `master_id` – Связь с мастером  
- `professional_service_id` – Связь с услугой  

📅 **Appointment** (Запись)  
- `id` – Уникальный идентификатор  
- `user_id` – Связь с клиентом  
- `master_id` – Связь с мастером  
- `professional_service_id` – Связь с услугой  
- `datetime` – Дата и время записи  
- `status` – Статус записи (запланирована, завершена, отменена)  

🏠 **Salon** (Салон - 1) 
- `id` – Уникальный идентификатор  
- `name` – Название  
- `address` – Адрес  
- `phone` – Контактный телефон  
- `working_hours` – Часы работы  

👤 **User** (Клиент)  
- `id` – Уникальный идентификатор  
- `username` – Логин  
- `password_hash` – Пароль
- `email` – Электронная почта  
- `phone` – Телефон  

💳 **Payment** (Оплата)  
- `id` – Уникальный идентификатор  
- `appointment_id` – Связь с записью  
- `payment_method` – Способ оплаты (карта, наличные и т. д.)  
- `amount` – Итоговая сумма  
- `status` – Статус (оплачен, ожидает, отменен)  

### Схема связей в БД:
- User (1) — (M) Appointment
- Master (1) — (M) Appointment
- ProfessionalService (1) — (M) Appointment
- Appointment (1) — (1) Payment
- Master (M) — (M) ProfessionalService (через Master_ProfessionalService)