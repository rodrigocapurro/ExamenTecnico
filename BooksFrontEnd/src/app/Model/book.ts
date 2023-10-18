export interface Book {
    title?: string;
    author?: string;
    publicationYear?: number;
    isbn?: string;
}

export interface BooksResponse
{
    cod_Http?: number;
    mensaje?: string;
    status?: string;
    booksList?: Book[];
}

