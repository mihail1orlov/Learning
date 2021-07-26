import {Component, Inject, OnInit} from '@angular/core';
import {AudioContext, isSupported} from "angular-audio-context";

@Component({
  selector: 'app-audio',
  templateUrl: './audio.component.html',
  styleUrls: ['./audio.component.scss']
})
export class AudioComponent implements OnInit {

  constructor(private audioContext: AudioContext,
              @Inject(isSupported) public isSupported: any) {
  }

  ngOnInit(): void {
  }

  public async beep() {
    if (this.audioContext.state === 'suspended') {
      await this.audioContext.resume();
    }

    const oscillatorNode = this.audioContext.createOscillator();

    oscillatorNode.onended = () => oscillatorNode.disconnect();
    oscillatorNode.connect(this.audioContext.destination);

    oscillatorNode.start();
    oscillatorNode.stop(this.audioContext.currentTime + 0.3);
  }
}
