FROM nginx:latest

# Install node & npm
RUN apt update -y; apt upgrade -y; apt install -y npm

WORKDIR /usr/src/app
COPY . /usr/src/app
RUN npm install
RUN npm run-script build

WORKDIR /usr/share/nginx/html/
RUN cp -R /usr/src/app/build/* /usr/share/nginx/html
