import gql from "graphql-tag";

export const createBo = gql`
mutation createB($title: String!)
{
  createBoard(title:$title, description:"description")
  {
    isSuccessfull
  }
}`;
