import {Injectable} from '@angular/core';
import {AudioContext} from "angular-audio-context";

@Injectable({
  providedIn: 'root'
})
export class AudioService {

  constructor(private audioContext: AudioContext) {
  }
}
