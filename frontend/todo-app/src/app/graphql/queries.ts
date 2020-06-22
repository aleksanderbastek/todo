import gql from "graphql-tag";

export const showBoard = gql`
query showBoard($id: String){
  board(id:$id){
    id
    title
    description
    creationDate
  }
}`;
