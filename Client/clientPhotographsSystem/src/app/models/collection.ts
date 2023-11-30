import { Image } from "./Image";

export interface Collection {
    itemId?: string;
    collectionSymbolization: string;
    title: string;
    images: Image[];
  }