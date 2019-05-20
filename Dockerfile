# Stage 1: Build time
FROM node:10.15-slim AS build

COPY . /src/

WORKDIR /src

RUN npm install

RUN npm run build

# Stage 2: Run time
FROM node:10.15-slim AS run

COPY --from=build /src/dist/ .

COPY --from=build /src/node_modules node_modules

EXPOSE 3000

CMD ["node", "app.js"]