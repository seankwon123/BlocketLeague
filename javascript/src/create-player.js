import { connectSdk } from "./utils/connect-sdk.js";
import { getRandomInt } from "./utils/random.js";


// TODO Pull address from wallet instead of passing it as an argument
// node ./src/create-token.js {collectionId} {address} {nickname}
// i.e. node ./src/create-token.js 3131 5HRADyd2sEVtpqh3cCdTdvfshMV7oK4xXJyM48i4r9S3TNGH Speedy777
export async function createToken (nickname) {
  // const args = process.argv.slice(2);
  // if (args.length < 3) {
  //   console.error("run this command: node ./src/create-player.js {address} {nickname}");
  //   process.exit(1);
  // }

  const collectionId = 3327;


  // const [_, nickname, owner,] = args;

  const {account, sdk} = await connectSdk();
  const owner = account.address;

  // TODO
  // Get pseudo-random car image for fun
  // const tokenImage = getRandomInt(2) === 0
  //   ? "https://gateway.pinata.cloud/ipfs/QmfWKy52e8pyH1jrLu4hwyAG6iwk6hcYa37DoVe8rdxXwV"
  //   : "https://gateway.pinata.cloud/ipfs/QmNn6jfFu1jE7xPC2oxJ75kY1RvA2tz9bpQDsqweX2kDig"

  const tokenTx = await sdk.token.createV2({
    collectionId,
    // image: tokenImage,
    owner,
    attributes: [
      {
        trait_type: "PlayerName",
        value: nickname,
      },
      {
        trait_type: "Victories",
        value: 0,
      },
      {
        trait_type: "Defeats",
        value: 0,
      },
      {
        trait_type: "Shots",
        value: 0,
      },
      {
        trait_type: "Saves",
        value: 0,
      },
    ],
  });

  const token = tokenTx.parsed;
  if (!token) throw Error("Cannot parse token");

  console.log(`Explore your player account NFT: https://uniquescan.io/opal/tokens/${token.collectionId}/${token.tokenId}`);
 
  process.exit(0);
}

// export const token = createToken(nickname).catch(e => {
//   console.log('Something wrong during token creation');
//   throw e;
// });;

// createToken().catch(e => {
//   console.log('Something wrong during token creation');
//   throw e;
// });
