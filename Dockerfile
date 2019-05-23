# Stage 1: Build time
FROM node:10.15-slim AS build

COPY . /src/

WORKDIR /src

RUN npm install

EXPOSE 3000

CMD ["node", "app.js"]