FROM node:19.3-alpine

WORKDIR /app/frontend

COPY . .

RUN npm ci

RUN npm run build

EXPOSE 3000

CMD [ "npx", "serve", "build" ]