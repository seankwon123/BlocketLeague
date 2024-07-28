import { Sr25519Account } from "@unique-nft/sr25519";
	
const mnemonic = Sr25519Account.generateMnemonic();
const account = Sr25519Account.fromUri(mnemonic);

console.log(mnemonic);
console.log(account);