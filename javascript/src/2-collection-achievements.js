import { connectSdk } from "./utils/connect-sdk.js";

const createCollection = async () => {
  const {sdk} = await connectSdk();

  const {parsed} = await sdk.collection.createV2({
    name: "Blocket League Achievements",
    description: "Achievements for Blocket League",
    symbol: "ACH",
    // TODO
    // cover_image: {url: "https://gateway.pinata.cloud/ipfs/QmWm5mPjmWqFvF2wyXbheumBWoEQpWm1f9GqGQfLfBYbDi"},
    // NOTICE: activate nesting in order to assign achievements
    permissions: {nesting: {collectionAdmin: true}},
    encodeOptions: {
      // NOTICE: we do not want to mutate tokens of the Achievements collection
      defaultPermission: {collectionAdmin: true, tokenOwner: false, mutable: false},
    }
  });

  if(!parsed) throw Error('Cannot parse minted collection');
  
  const collectionId = parsed.collectionId;
  console.log(`Explore the Blocket League Achievements collection: https://uniquescan.io/opal/collections/${collectionId}`);

  process.exit(0);
}


createCollection().catch(e => {
  console.log('Something wrong during Blocket League Achievements collection creation');
  throw e;
});
