Machine Processor Count: 20
Machine OS Version: Microsoft Windows NT 10.0.26200.0

================================================== Task1 ==================================================

  ── HTML Tag Frequency ──
  Documents: 1000

  [Sequential                                                                                                                  ]       84 ms
  [PLINQ Map-Reduce                                                                                                            ]       40 ms
  [PLINQ Map-Reduce degree=2]: 2.10x speedup
  [PLINQ Map-Reduce                                                                                                            ]       20 ms
  [PLINQ Map-Reduce degree=4]: 4.20x speedup
  [PLINQ Map-Reduce                                                                                                            ]       16 ms
  [PLINQ Map-Reduce degree=5]: 5.25x speedup
  [PLINQ Map-Reduce                                                                                                            ]       15 ms
  [PLINQ Map-Reduce degree=6]: 5.60x speedup
  [PLINQ Map-Reduce                                                                                                            ]       13 ms
  [PLINQ Map-Reduce degree=10]: 6.46x speedup
  [PLINQ Map-Reduce                                                                                                            ]       14 ms
  [PLINQ Map-Reduce degree=20]: 6.00x speedup
  [PLINQ Map-Reduce                                                                                                            ]       13 ms
  [PLINQ Map-Reduce degree=25]: 6.46x speedup
  [PLINQ Map-Reduce                                                                                                            ]       12 ms
  [PLINQ Map-Reduce degree=26]: 7.00x speedup
  [PLINQ Map-Reduce                                                                                                            ]       11 ms
  [PLINQ Map-Reduce degree=30]: 7.64x speedup
  [Fork-Join                                                                                                                   ]       35 ms
  [Fork-Join degree=2]: 2.40x speedup
  [Fork-Join                                                                                                                   ]       22 ms
  [Fork-Join degree=4]: 3.82x speedup
  [Fork-Join                                                                                                                   ]       22 ms
  [Fork-Join degree=5]: 3.82x speedup
  [Fork-Join                                                                                                                   ]       16 ms
  [Fork-Join degree=6]: 5.25x speedup
  [Fork-Join                                                                                                                   ]       13 ms
  [Fork-Join degree=10]: 6.46x speedup
  [Fork-Join                                                                                                                   ]       12 ms
  [Fork-Join degree=20]: 7.00x speedup
  [Fork-Join                                                                                                                   ]       12 ms
  [Fork-Join degree=25]: 7.00x speedup
  [Fork-Join                                                                                                                   ]       12 ms
  [Fork-Join degree=26]: 7.00x speedup
  [Fork-Join                                                                                                                   ]       11 ms
  [Fork-Join degree=30]: 7.64x speedup
  [Dataflow Worker Pool                                                                                                        ]       43 ms
  [Dataflow Worker Pool degree=2]: 1.95x speedup
  [Dataflow Worker Pool                                                                                                        ]       21 ms
  [Dataflow Worker Pool degree=4]: 4.00x speedup
  [Dataflow Worker Pool                                                                                                        ]       20 ms
  [Dataflow Worker Pool degree=5]: 4.20x speedup
  [Dataflow Worker Pool                                                                                                        ]       17 ms
  [Dataflow Worker Pool degree=6]: 4.94x speedup
  [Dataflow Worker Pool                                                                                                        ]       13 ms
  [Dataflow Worker Pool degree=10]: 6.46x speedup
  [Dataflow Worker Pool                                                                                                        ]        9 ms
  [Dataflow Worker Pool degree=20]: 9.33x speedup
  [Dataflow Worker Pool                                                                                                        ]       10 ms
  [Dataflow Worker Pool degree=25]: 8.40x speedup
  [Dataflow Worker Pool                                                                                                        ]       10 ms
  [Dataflow Worker Pool degree=26]: 8.40x speedup
  [Dataflow Worker Pool                                                                                                        ]       11 ms
  [Dataflow Worker Pool degree=30]: 7.64x speedup

  ── Array Stats - min / max / median / avg ──
  Array size: 1,000,000

  [Sequential                                                                                                                  ]      137 ms
    min=3.53  max=999998.41  median=500891.42  avg=500242.58
  [PLINQ Map-Reduce (degree=2)                                                                                                 ]      140 ms
  [PLINQ Map-Reduce degree=2]: 0.98x speedup
  [PLINQ Map-Reduce (degree=4)                                                                                                 ]      144 ms
  [PLINQ Map-Reduce degree=4]: 0.95x speedup
  [PLINQ Map-Reduce (degree=5)                                                                                                 ]      102 ms
  [PLINQ Map-Reduce degree=5]: 1.34x speedup
  [PLINQ Map-Reduce (degree=6)                                                                                                 ]       65 ms
  [PLINQ Map-Reduce degree=6]: 2.11x speedup
  [PLINQ Map-Reduce (degree=10)                                                                                                ]       62 ms
  [PLINQ Map-Reduce degree=10]: 2.21x speedup
  [PLINQ Map-Reduce (degree=20)                                                                                                ]       62 ms
  [PLINQ Map-Reduce degree=20]: 2.21x speedup
  [PLINQ Map-Reduce (degree=25)                                                                                                ]       65 ms
  [PLINQ Map-Reduce degree=25]: 2.11x speedup
  [PLINQ Map-Reduce (degree=26)                                                                                                ]       63 ms
  [PLINQ Map-Reduce degree=26]: 2.17x speedup
  [PLINQ Map-Reduce (degree=30)                                                                                                ]       59 ms
  [PLINQ Map-Reduce degree=30]: 2.32x speedup
  [Fork-Join (degree=2)                                                                                                        ]       39 ms
  [Fork-Join degree=2]: 3.51x speedup
  [Fork-Join (degree=4)                                                                                                        ]       29 ms
  [Fork-Join degree=4]: 4.72x speedup
  [Fork-Join (degree=5)                                                                                                        ]       31 ms
  [Fork-Join degree=5]: 4.42x speedup
  [Fork-Join (degree=6)                                                                                                        ]       31 ms
  [Fork-Join degree=6]: 4.42x speedup
  [Fork-Join (degree=10)                                                                                                       ]       34 ms
  [Fork-Join degree=10]: 4.03x speedup
  [Fork-Join (degree=20)                                                                                                       ]       52 ms
  [Fork-Join degree=20]: 2.63x speedup
  [Fork-Join (degree=25)                                                                                                       ]       68 ms
  [Fork-Join degree=25]: 2.01x speedup
  [Fork-Join (degree=26)                                                                                                       ]       62 ms
  [Fork-Join degree=26]: 2.21x speedup
  [Fork-Join (degree=30)                                                                                                       ]       82 ms
  [Fork-Join degree=30]: 1.67x speedup
  [Dataflow Worker Pool (degree=2)                                                                                             ]       45 ms
  [Dataflow Worker Pool degree=2]: 3.04x speedup
  [Dataflow Worker Pool (degree=4)                                                                                             ]       31 ms
  [Dataflow Worker Pool degree=4]: 4.42x speedup
  [Dataflow Worker Pool (degree=5)                                                                                             ]       29 ms
  [Dataflow Worker Pool degree=5]: 4.72x speedup
  [Dataflow Worker Pool (degree=6)                                                                                             ]       30 ms
  [Dataflow Worker Pool degree=6]: 4.57x speedup
  [Dataflow Worker Pool (degree=10)                                                                                            ]       34 ms
  [Dataflow Worker Pool degree=10]: 4.03x speedup
  [Dataflow Worker Pool (degree=20)                                                                                            ]       52 ms
  [Dataflow Worker Pool degree=20]: 2.63x speedup
  [Dataflow Worker Pool (degree=25)                                                                                            ]       59 ms
  [Dataflow Worker Pool degree=25]: 2.32x speedup
  [Dataflow Worker Pool (degree=26)                                                                                            ]       60 ms
  [Dataflow Worker Pool degree=26]: 2.28x speedup
  [Dataflow Worker Pool (degree=30)                                                                                            ]       71 ms
  [Dataflow Worker Pool degree=30]: 1.93x speedup

  ── Matrix Multiplication N?N ──
  Matrix size: 1000?1000  (1,000,000 elements each)

  [Sequential                                                                                                                  ]     4176 ms
  [PLINQ Map-Reduce (degree=2)                                                                                                 ]     2214 ms
  [PLINQ Map-Reduce degree=2]: 1.89x speedup
  [PLINQ Map-Reduce (degree=4)                                                                                                 ]     1189 ms
  [PLINQ Map-Reduce degree=4]: 3.51x speedup
  [PLINQ Map-Reduce (degree=5)                                                                                                 ]      941 ms
  [PLINQ Map-Reduce degree=5]: 4.44x speedup
  [PLINQ Map-Reduce (degree=6)                                                                                                 ]     1110 ms
  [PLINQ Map-Reduce degree=6]: 3.76x speedup
  [PLINQ Map-Reduce (degree=10)                                                                                                ]      820 ms
  [PLINQ Map-Reduce degree=10]: 5.09x speedup
  [PLINQ Map-Reduce (degree=20)                                                                                                ]      736 ms
  [PLINQ Map-Reduce degree=20]: 5.67x speedup
  [PLINQ Map-Reduce (degree=25)                                                                                                ]      673 ms
  [PLINQ Map-Reduce degree=25]: 6.21x speedup
  [PLINQ Map-Reduce (degree=26)                                                                                                ]      648 ms
  [PLINQ Map-Reduce degree=26]: 6.44x speedup
  [PLINQ Map-Reduce (degree=30)                                                                                                ]      592 ms
  [PLINQ Map-Reduce degree=30]: 7.05x speedup
  [Fork-Join (degree=2)                                                                                                        ]     3108 ms
  [Fork-Join degree=2]: 1.34x speedup
  [Fork-Join (degree=4)                                                                                                        ]     1599 ms
  [Fork-Join degree=4]: 2.61x speedup
  [Fork-Join (degree=5)                                                                                                        ]     1440 ms
  [Fork-Join degree=5]: 2.90x speedup
  [Fork-Join (degree=6)                                                                                                        ]     1369 ms
  [Fork-Join degree=6]: 3.05x speedup
  [Fork-Join (degree=10)                                                                                                       ]      924 ms
  [Fork-Join degree=10]: 4.52x speedup
  [Fork-Join (degree=20)                                                                                                       ]      590 ms
  [Fork-Join degree=20]: 7.08x speedup
  [Fork-Join (degree=25)                                                                                                       ]      724 ms
  [Fork-Join degree=25]: 5.77x speedup
  [Fork-Join (degree=26)                                                                                                       ]      678 ms
  [Fork-Join degree=26]: 6.16x speedup
  [Fork-Join (degree=30)                                                                                                       ]      691 ms
  [Fork-Join degree=30]: 6.04x speedup
  [Dataflow Worker Pool (degree=2)                                                                                             ]     2619 ms
  [Dataflow Worker Pool degree=2]: 1.59x speedup
  [Dataflow Worker Pool (degree=4)                                                                                             ]     1352 ms
  [Dataflow Worker Pool degree=4]: 3.09x speedup
  [Dataflow Worker Pool (degree=5)                                                                                             ]     1096 ms
  [Dataflow Worker Pool degree=5]: 3.81x speedup
  [Dataflow Worker Pool (degree=6)                                                                                             ]     1055 ms
  [Dataflow Worker Pool degree=6]: 3.96x speedup
  [Dataflow Worker Pool (degree=10)                                                                                            ]      820 ms
  [Dataflow Worker Pool degree=10]: 5.09x speedup
  [Dataflow Worker Pool (degree=20)                                                                                            ]      514 ms
  [Dataflow Worker Pool degree=20]: 8.12x speedup
  [Dataflow Worker Pool (degree=25)                                                                                            ]      494 ms
  [Dataflow Worker Pool degree=25]: 8.45x speedup
  [Dataflow Worker Pool (degree=26)                                                                                            ]      523 ms
  [Dataflow Worker Pool degree=26]: 7.98x speedup
  [Dataflow Worker Pool (degree=30)                                                                                            ]      509 ms
  [Dataflow Worker Pool degree=30]: 8.20x speedup

================================================== Task2 ==================================================

  ── Financial Transaction Processing ──
  Generating 2,000,000 transactions with Bogus... done.
  Cashback threshold: UserId > 10 ␦ 20%

  [Sequential                                                                                                                  ]      286 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208

  ? Pipeline (TPL Dataflow: Convert + Cashback ␦ Aggregate)
  [Pipeline (degree=2)                                                                                                         ]     2191 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Pipeline degree=2]: 0.13x speedup
  [Pipeline (degree=4)                                                                                                         ]     3036 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Pipeline degree=4]: 0.09x speedup
  [Pipeline (degree=5)                                                                                                         ]     3336 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Pipeline degree=5]: 0.09x speedup
  [Pipeline (degree=6)                                                                                                         ]     3495 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Pipeline degree=6]: 0.08x speedup
  [Pipeline (degree=10)                                                                                                        ]     3842 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Pipeline degree=10]: 0.07x speedup
  [Pipeline (degree=20)                                                                                                        ]     4584 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Pipeline degree=20]: 0.06x speedup
  [Pipeline (degree=25)                                                                                                        ]     4794 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Pipeline degree=25]: 0.06x speedup
  [Pipeline (degree=26)                                                                                                        ]     4151 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Pipeline degree=26]: 0.07x speedup
  [Pipeline (degree=30)                                                                                                        ]     4383 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Pipeline degree=30]: 0.07x speedup

  ? Producer-Consumer (System.Threading.Channels)
  [Producer-Consumer (consumers=2)                                                                                             ]      558 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Producer-Consumer degree=2]: 0.51x speedup
  [Producer-Consumer (consumers=4)                                                                                             ]     1013 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Producer-Consumer degree=4]: 0.28x speedup
  [Producer-Consumer (consumers=5)                                                                                             ]     1419 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Producer-Consumer degree=5]: 0.20x speedup
  [Producer-Consumer (consumers=6)                                                                                             ]     1712 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Producer-Consumer degree=6]: 0.17x speedup
  [Producer-Consumer (consumers=10)                                                                                            ]     2319 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Producer-Consumer degree=10]: 0.12x speedup
  [Producer-Consumer (consumers=20)                                                                                            ]     3003 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Producer-Consumer degree=20]: 0.10x speedup
  [Producer-Consumer (consumers=25)                                                                                            ]     3491 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Producer-Consumer degree=25]: 0.08x speedup
  [Producer-Consumer (consumers=26)                                                                                            ]     3604 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Producer-Consumer degree=26]: 0.08x speedup
  [Producer-Consumer (consumers=30)                                                                                            ]     2887 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 17,559,141,439.12
    Final UAH         : 158,128,578,526.71
    Cashback eligible : 999,208
  [Producer-Consumer degree=30]: 0.10x speedup
  