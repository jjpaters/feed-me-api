# rm -r dist
# npm run build
mkdir dist
cp index.js ./dist/index.js
cp package.json ./dist/package.json
cp package-lock.json ./dist/package-lock.json
cd ./dist/ && npm install --production
zip -r function.zip .
cp function.zip ../function.zip