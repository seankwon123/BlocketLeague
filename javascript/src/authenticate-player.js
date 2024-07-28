import { connectSdk } from "./utils/connect-sdk.js";
// import { CollectionIdArguments, CollectionInfoWithSchema } from '@unique-nft/substrate-client/types';

const checkToken = async () => {

    

    const collectionId = 3327;
    const {account, sdk} = await connectSdk();

    const userAddress = '5GpdQUmmabT9UazczET4Y3ZpNyPjaiWw1uies3uEpQuQNtfz';

    console.log(account.address );
    // try {
    //     // Fetch tokens from the collection
    //     const result = await sdk.collection.tokens({
    //       collectionId: collectionId,
    //     //   limit: limit,
    //     //   offset: offset
    //     });

    
    //     if (result.error) {
    //       throw new Error(`Error fetching tokens: ${result.error.message}`);
    //     }
    //     console.log(result);
    //     return result.tokens;
    //   } catch (error) {
    //     console.error('Error:', error);
    //     throw error;
    //   }
    try {
        // Get all token IDs in the collection
        const result = await sdk.collection.tokens({
          collectionId: collectionId,
        });
    
        if (!result.ids || !Array.isArray(result.ids)) {
          throw new Error('Unexpected response format when fetching token IDs');
        }
    
        const tokenIds = result.ids;
    
        // Function to check token ownership
        async function checkTokenOwnership(tokenId) {
          const tokenInfo = await sdk.token.get({
            collectionId: collectionId,
            tokenId: tokenId,
          });
    
          return tokenInfo.owner === userAddress;
        }
    
        // Check ownership for each token
        for (const tokenId of tokenIds) {
          const isOwner = await checkTokenOwnership(tokenId);
          if (isOwner) {
            console.log(`Token found for user wallet : TokenId ${tokenId}`);
            return tokenId; // Return the token ID if it belongs to the user
          }
        }
    
        // If no matching token is found
        return null;
    
      } catch (error) {
        console.error('Something wrong during token authentication', error);
        throw error;
      }
    }
    //}

    // try {
    //     const tokens = await sdk.collection.tokens .token.list({
    //         collectionId: collectionId,
    //         limit: 1 // Adjust the limit as needed
    //     });

    //     console.log(`Checking ${tokens.items.length} tokens in collection ${collectionId}`);

    //     for (const token of tokens.items) {
    //         if (token.owner === userAddress) {
    //             console.log(`Token found for user: TokenId ${token.tokenId}`);
    //             return token;
    //         }
    //     }

    //     console.log('No token found for the user in this collection');
    //     return null;
    // } catch (error) {
    //     console.error('Error fetching tokens from the collection:', error);
    //     return null;
    // }

    // const getCollectionArgs =  CollectionIdArguments({ collectionId: 3327 }); 

    // const collection = await sdk.collection.get(getCollectionArgs);


//   const result = await sdk.token.get({
//     collectionId: collectionId,
//     owner: userAddress,
//     // owner: account.userAddress,
//     // limit: 1  // We only need to know if at least one exists
//   });

//   console.log('result', result);

//   if (result.items.length > 0) {
//     console.log('NFT found for user:', result.items[0]);
//     return result.items[0];
//   } else {
//     console.log('No NFT found for user in this collection');
//     return null;
//   }
// }

//   const collectionInfo = await sdk.collection.get({ collectionId });
//   console.log('collectionInfo', collectionInfo);
//   const totalTokens = collectionInfo.tokensTotalCount;

//   console.log(`Checking ${totalTokens} tokens in collection ${collectionId}`);

//   for (let tokenId = 1; tokenId <= totalTokens; tokenId++) {
//     try {
//       const token = await sdk.token.get({
//         collectionId: collectionId,
//         tokenId: tokenId
//       });

//       if (token.owner === userAddress) {
//         console.log(`Token found for user: TokenId ${tokenId}`);
//         return token;
//       }
//     } catch (error) {
//       // If token doesn't exist or there's an error, continue to the next token
//       console.log(`Error checking token ${tokenId}:`, error.message);
//     }
//   }

//   console.log('No token found for the user in this collection');
//   return null;
// }

checkToken().catch(e => {
    console.log('Something wrong during token authentication');
    throw e;
  });
  

// // Usage
// const collectionId = 1234; // Replace with your actual collection ID
// const userAddress = '5FnZdznv48uisWyxdr9mzNHagQXQMkZtSfhFPs8iCk1dcTo5'; // Replace with the user's address

// checkUserNFTInCollection(collectionId, userAddress)
//   .then(nft => {
//     if (nft) {
//       console.log('NFT ID:', nft.tokenId);
//       console.log('NFT Attributes:', nft.attributes);
//     }
//   })
//   .catch(error => console.error('Error checking for NFT:', error));