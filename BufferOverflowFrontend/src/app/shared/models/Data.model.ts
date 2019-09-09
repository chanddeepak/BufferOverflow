import { Questions } from './Questions.model';
import { Answers } from './Answers.model';
import { User } from './User.model';
import { Tags } from './Tags.model';
import { Votes } from './Votes.model';

export class Data {
  QuestionDetail: Questions;
  AnswerDetail: Answers;
  UserDetail: User;
  TagDetail: Array<Tags> = [];
  VoteDetail: Votes;
  TotalVote: number;
}
