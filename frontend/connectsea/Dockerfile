FROM node:24

WORKDIR /usr/src/app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build --prod

RUN npm install -g @angular/cli

EXPOSE 4200

CMD [ "ng", "serve", "--host", "0.0.0.0" ]
