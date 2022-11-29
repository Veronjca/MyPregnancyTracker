import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { filter, first } from 'rxjs';
import { TopicsService } from 'src/app/services/topics.service';
import { TopicModel } from 'src/app/models/topic.model';

@Component({
  selector: 'app-topics-page',
  templateUrl: './topics-page.component.html',
  styleUrls: ['./topics-page.component.scss']
})
export class TopicsPageComponent implements OnInit {
  categoryId!: number;
  topics: TopicModel[] = [];

  constructor(private route: ActivatedRoute,
    private topicsService: TopicsService) {
    this.route.queryParams.subscribe(params => {
      this.categoryId = Number(params['categoryId']);
    })
   }

  ngOnInit(): void {
    this.topicsService.getAllTopics(this.categoryId)
                      .pipe(filter(x => !!x), first())
                      .subscribe(response => this.topics = response);
  }

}
