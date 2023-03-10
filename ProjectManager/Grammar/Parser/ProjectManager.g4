grammar ProjectManager;

program: project EOF;
project: heading body;
body: iterations? jobs;

heading: PROJECT_LBL NL DESCRIPTION;

iterations: NL+ ITERATION_INDENT iteration_body+;
iteration_body: NL+ TEXT date milestones;

milestones: NL+ MILESTONES_INDENT milestone+;
milestone: NL+ DOUBLE_SPACED_TEXT;

jobs: NL+ JOBS_IDENT job_body+;
job_body:
	NL+ TEXT iteration? duration start_date predecessors? priority? size? labels?;
iteration: NL+ ITERATIONS_REFERENCE TEXT;
duration: NL+ DURATION_IDENT NUM;
priority: NL+ PRIORITY_IDENT NUM;
size: NL+ SIZE_IDENT NUM;
labels: NL+ LABELS_INDENT label+;
label: NL+ DOUBLE_SPACED_TEXT;
predecessors: NL+ PREDCESSORS_INDENT predcessor+;
predcessor: NL+ DOUBLE_SPACED_TEXT;

date: start_date end_date;
start_date: NL+ START_DATE DATE;
end_date: NL+ END_DATE DATE;

//Lexer
SKIPPING: [ \t\r]+ -> skip;

PROJECT_LBL: '#' TEXT;
DESCRIPTION: '>' TEXT;

ITERATION_INDENT: '##' WS+ 'Iterations';

JOBS_IDENT: '##' WS+ 'Jobs';
ITERATIONS_REFERENCE: WS 'Iteration:';
DURATION_IDENT: WS 'Duration:' WS*;
PRIORITY_IDENT: WS 'Priority:' WS*;
SIZE_IDENT: WS 'Size:' WS*;
LABELS_INDENT: WS 'Labels:';
PREDCESSORS_INDENT: WS 'Predecessors:';

START_DATE: WS 'Start Date:' WS*;
END_DATE: WS 'End Date:' WS*;

MILESTONES_INDENT: WS 'Milestones:';
DOUBLE_SPACED_TEXT: WS WS TEXT;

DATE: [0-9][0-9][0-9][0-9] '-' [0-9][0-9] '-' [0-9][0-9];

NUM: [0-9]+;
TEXT: [A-Za-z_0-9 ]+;

NL: [\n\r];
WS: [ \t];
