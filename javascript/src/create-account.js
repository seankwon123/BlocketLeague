import { Sr25519Account } from "@unique-nft/sr25519";
import {createToken} from "./create-player.js";

async function createAccount (nickname) {
    const mnemonic = Sr25519Account.generateMnemonic();
    const account = Sr25519Account.fromUri(mnemonic);

    console.log(mnemonic);
    console.log(account);


    await createToken(nickname);

    return {
        mnemonic,
        account
    }

}

createAccount('testUser3').catch(e => {
    console.log('Something wrong during account creation');
    throw e;
})
