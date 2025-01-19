import { getTopTenParticipants } from "./ParticipantsApi";
import { Participant } from "../../../Models/Participant";

interface GetParticipants {
  participants: Participant[];
}

export const FetchTopTenParticipants = async (): Promise<
  GetParticipants | undefined
> => {
  try {
    const data = await getTopTenParticipants();
    return { participants: data };
  } catch (error) {
    console.log(error);
  }
};
