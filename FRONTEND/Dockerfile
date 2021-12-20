FROM node:16.13.0

ARG BASE_DIR="/"

WORKDIR /app

COPY ${BASE_DIR}/package*.json ./


RUN npm install 

COPY ${BASE_DIR}/. .

RUN npm run build
EXPOSE 3000
CMD [ "npm", "start" ]