Machine Processor Count: 20
Machine OS Version: Microsoft Windows NT 10.0.26200.0

================================================== Task1 ==================================================

  ── HTML Tag Frequency ──
  Documents: 1000

  [Sequential                                                                                                                  ]       88 ms
  [PLINQ Map-Reduce                                                                                                            ]       56 ms
  [PLINQ Map-Reduce degree=2]: 1.57x speedup
  [PLINQ Map-Reduce                                                                                                            ]       24 ms
  [PLINQ Map-Reduce degree=4]: 3.67x speedup
  [PLINQ Map-Reduce                                                                                                            ]       18 ms
  [PLINQ Map-Reduce degree=5]: 4.89x speedup
  [PLINQ Map-Reduce                                                                                                            ]       15 ms
  [PLINQ Map-Reduce degree=6]: 5.87x speedup
  [PLINQ Map-Reduce                                                                                                            ]       14 ms
  [PLINQ Map-Reduce degree=10]: 6.29x speedup
  [PLINQ Map-Reduce                                                                                                            ]       13 ms
  [PLINQ Map-Reduce degree=20]: 6.77x speedup
  [PLINQ Map-Reduce                                                                                                            ]       13 ms
  [PLINQ Map-Reduce degree=25]: 6.77x speedup
  [PLINQ Map-Reduce                                                                                                            ]       14 ms
  [PLINQ Map-Reduce degree=26]: 6.29x speedup
  [PLINQ Map-Reduce                                                                                                            ]       12 ms
  [PLINQ Map-Reduce degree=30]: 7.33x speedup
  [Fork-Join                                                                                                                   ]       39 ms
  [Fork-Join degree=2]: 2.26x speedup
  [Fork-Join                                                                                                                   ]       19 ms
  [Fork-Join degree=4]: 4.63x speedup
  [Fork-Join                                                                                                                   ]       16 ms
  [Fork-Join degree=5]: 5.50x speedup
  [Fork-Join                                                                                                                   ]       14 ms
  [Fork-Join degree=6]: 6.29x speedup
  [Fork-Join                                                                                                                   ]       12 ms
  [Fork-Join degree=10]: 7.33x speedup
  [Fork-Join                                                                                                                   ]       11 ms
  [Fork-Join degree=20]: 8.00x speedup
  [Fork-Join                                                                                                                   ]       12 ms
  [Fork-Join degree=25]: 7.33x speedup
  [Fork-Join                                                                                                                   ]       12 ms
  [Fork-Join degree=26]: 7.33x speedup
  [Fork-Join                                                                                                                   ]       11 ms
  [Fork-Join degree=30]: 8.00x speedup
  [Dataflow Worker Pool                                                                                                        ]       41 ms
  [Dataflow Worker Pool degree=2]: 2.15x speedup
  [Dataflow Worker Pool                                                                                                        ]       20 ms
  [Dataflow Worker Pool degree=4]: 4.40x speedup
  [Dataflow Worker Pool                                                                                                        ]       17 ms
  [Dataflow Worker Pool degree=5]: 5.18x speedup
  [Dataflow Worker Pool                                                                                                        ]       15 ms
  [Dataflow Worker Pool degree=6]: 5.87x speedup
  [Dataflow Worker Pool                                                                                                        ]       12 ms
  [Dataflow Worker Pool degree=10]: 7.33x speedup
  [Dataflow Worker Pool                                                                                                        ]        9 ms
  [Dataflow Worker Pool degree=20]: 9.78x speedup
  [Dataflow Worker Pool                                                                                                        ]       10 ms
  [Dataflow Worker Pool degree=25]: 8.80x speedup
  [Dataflow Worker Pool                                                                                                        ]       10 ms
  [Dataflow Worker Pool degree=26]: 8.80x speedup
  [Dataflow Worker Pool                                                                                                        ]       10 ms
  [Dataflow Worker Pool degree=30]: 8.80x speedup

  ── Array Stats - min / max / median / avg ──
  Array size: 1,000,000

  [Sequential                                                                                                                  ]      138 ms
    min=1.74  max=999999.76  median=500331.26  avg=499854.34
  [PLINQ Map-Reduce (degree=2)                                                                                                 ]      138 ms
  [PLINQ Map-Reduce degree=2]: 1.00x speedup
  [PLINQ Map-Reduce (degree=4)                                                                                                 ]      125 ms
  [PLINQ Map-Reduce degree=4]: 1.10x speedup
  [PLINQ Map-Reduce (degree=5)                                                                                                 ]       64 ms
  [PLINQ Map-Reduce degree=5]: 2.16x speedup
  [PLINQ Map-Reduce (degree=6)                                                                                                 ]       64 ms
  [PLINQ Map-Reduce degree=6]: 2.16x speedup
  [PLINQ Map-Reduce (degree=10)                                                                                                ]       62 ms
  [PLINQ Map-Reduce degree=10]: 2.23x speedup
  [PLINQ Map-Reduce (degree=20)                                                                                                ]       62 ms
  [PLINQ Map-Reduce degree=20]: 2.23x speedup
  [PLINQ Map-Reduce (degree=25)                                                                                                ]       62 ms
  [PLINQ Map-Reduce degree=25]: 2.23x speedup
  [PLINQ Map-Reduce (degree=26)                                                                                                ]       64 ms
  [PLINQ Map-Reduce degree=26]: 2.16x speedup
  [PLINQ Map-Reduce (degree=30)                                                                                                ]       62 ms
  [PLINQ Map-Reduce degree=30]: 2.23x speedup
  [Fork-Join (degree=2)                                                                                                        ]       40 ms
  [Fork-Join degree=2]: 3.45x speedup
  [Fork-Join (degree=4)                                                                                                        ]       30 ms
  [Fork-Join degree=4]: 4.60x speedup
  [Fork-Join (degree=5)                                                                                                        ]       31 ms
  [Fork-Join degree=5]: 4.45x speedup
  [Fork-Join (degree=6)                                                                                                        ]       28 ms
  [Fork-Join degree=6]: 4.93x speedup
  [Fork-Join (degree=10)                                                                                                       ]       33 ms
  [Fork-Join degree=10]: 4.18x speedup
  [Fork-Join (degree=20)                                                                                                       ]       49 ms
  [Fork-Join degree=20]: 2.82x speedup
  [Fork-Join (degree=25)                                                                                                       ]       57 ms
  [Fork-Join degree=25]: 2.42x speedup
  [Fork-Join (degree=26)                                                                                                       ]       62 ms
  [Fork-Join degree=26]: 2.23x speedup
  [Fork-Join (degree=30)                                                                                                       ]       65 ms
  [Fork-Join degree=30]: 2.12x speedup
  [Dataflow Worker Pool (degree=2)                                                                                             ]       43 ms
  [Dataflow Worker Pool degree=2]: 3.21x speedup
  [Dataflow Worker Pool (degree=4)                                                                                             ]       29 ms
  [Dataflow Worker Pool degree=4]: 4.76x speedup
  [Dataflow Worker Pool (degree=5)                                                                                             ]       28 ms
  [Dataflow Worker Pool degree=5]: 4.93x speedup
  [Dataflow Worker Pool (degree=6)                                                                                             ]       28 ms
  [Dataflow Worker Pool degree=6]: 4.93x speedup
  [Dataflow Worker Pool (degree=10)                                                                                            ]       35 ms
  [Dataflow Worker Pool degree=10]: 3.94x speedup
  [Dataflow Worker Pool (degree=20)                                                                                            ]       62 ms
  [Dataflow Worker Pool degree=20]: 2.23x speedup
  [Dataflow Worker Pool (degree=25)                                                                                            ]       60 ms
  [Dataflow Worker Pool degree=25]: 2.30x speedup
  [Dataflow Worker Pool (degree=26)                                                                                            ]       59 ms
  [Dataflow Worker Pool degree=26]: 2.34x speedup
  [Dataflow Worker Pool (degree=30)                                                                                            ]       68 ms
  [Dataflow Worker Pool degree=30]: 2.03x speedup

  ── Matrix Multiplication N?N ──
  Matrix size: 1000?1000  (1,000,000 elements each)

  [Sequential                                                                                                                  ]     3390 ms
  [PLINQ Map-Reduce (degree=2)                                                                                                 ]     2332 ms
  [PLINQ Map-Reduce degree=2]: 1.45x speedup
  [PLINQ Map-Reduce (degree=4)                                                                                                 ]      968 ms
  [PLINQ Map-Reduce degree=4]: 3.50x speedup
  [PLINQ Map-Reduce (degree=5)                                                                                                 ]      807 ms
  [PLINQ Map-Reduce degree=5]: 4.20x speedup
  [PLINQ Map-Reduce (degree=6)                                                                                                 ]      680 ms
  [PLINQ Map-Reduce degree=6]: 4.99x speedup
  [PLINQ Map-Reduce (degree=10)                                                                                                ]      586 ms
  [PLINQ Map-Reduce degree=10]: 5.78x speedup
  [PLINQ Map-Reduce (degree=20)                                                                                                ]      455 ms
  [PLINQ Map-Reduce degree=20]: 7.45x speedup
  [PLINQ Map-Reduce (degree=25)                                                                                                ]      510 ms
  [PLINQ Map-Reduce degree=25]: 6.65x speedup
  [PLINQ Map-Reduce (degree=26)                                                                                                ]      508 ms
  [PLINQ Map-Reduce degree=26]: 6.67x speedup
  [PLINQ Map-Reduce (degree=30)                                                                                                ]      499 ms
  [PLINQ Map-Reduce degree=30]: 6.79x speedup
  [Fork-Join (degree=2)                                                                                                        ]     2198 ms
  [Fork-Join degree=2]: 1.54x speedup
  [Fork-Join (degree=4)                                                                                                        ]     1169 ms
  [Fork-Join degree=4]: 2.90x speedup
  [Fork-Join (degree=5)                                                                                                        ]      910 ms
  [Fork-Join degree=5]: 3.73x speedup
  [Fork-Join (degree=6)                                                                                                        ]      884 ms
  [Fork-Join degree=6]: 3.83x speedup
  [Fork-Join (degree=10)                                                                                                       ]     1069 ms
  [Fork-Join degree=10]: 3.17x speedup
  [Fork-Join (degree=20)                                                                                                       ]     1139 ms
  [Fork-Join degree=20]: 2.98x speedup
  [Fork-Join (degree=25)                                                                                                       ]     1442 ms
  [Fork-Join degree=25]: 2.35x speedup
  [Fork-Join (degree=26)                                                                                                       ]     1359 ms
  [Fork-Join degree=26]: 2.49x speedup
  [Fork-Join (degree=30)                                                                                                       ]     1131 ms
  [Fork-Join degree=30]: 3.00x speedup
  [Dataflow Worker Pool (degree=2)                                                                                             ]     4634 ms
  [Dataflow Worker Pool degree=2]: 0.73x speedup
  [Dataflow Worker Pool (degree=4)                                                                                             ]     2680 ms
  [Dataflow Worker Pool degree=4]: 1.26x speedup
  [Dataflow Worker Pool (degree=5)                                                                                             ]     1999 ms
  [Dataflow Worker Pool degree=5]: 1.70x speedup
  [Dataflow Worker Pool (degree=6)                                                                                             ]     1715 ms
  [Dataflow Worker Pool degree=6]: 1.98x speedup
  [Dataflow Worker Pool (degree=10)                                                                                            ]     1101 ms
  [Dataflow Worker Pool degree=10]: 3.08x speedup
  [Dataflow Worker Pool (degree=20)                                                                                            ]     1060 ms
  [Dataflow Worker Pool degree=20]: 3.20x speedup
  [Dataflow Worker Pool (degree=25)                                                                                            ]     1054 ms
  [Dataflow Worker Pool degree=25]: 3.22x speedup
  [Dataflow Worker Pool (degree=26)                                                                                            ]     1030 ms
  [Dataflow Worker Pool degree=26]: 3.29x speedup
  [Dataflow Worker Pool (degree=30)                                                                                            ]     1043 ms
  [Dataflow Worker Pool degree=30]: 3.25x speedup

================================================== Task2 ==================================================

  ── Financial Transaction Processing ──
  Generating 2,000,000 transactions with Bogus... done.
  Cashback threshold: UserId > 10000000 ␦ 20%

  [Sequential                                                                                                                  ]      416 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0

  ? Pipeline (TPL Dataflow: Convert + Cashback ␦ Aggregate)
  [Pipeline (degree=2)                                                                                                         ]     2014 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Pipeline degree=2]: 0.21x speedup
  [Pipeline (degree=4)                                                                                                         ]     2396 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Pipeline degree=4]: 0.17x speedup
  [Pipeline (degree=5)                                                                                                         ]     2786 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Pipeline degree=5]: 0.15x speedup
  [Pipeline (degree=6)                                                                                                         ]     2721 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Pipeline degree=6]: 0.15x speedup
  [Pipeline (degree=10)                                                                                                        ]     3489 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Pipeline degree=10]: 0.12x speedup
  [Pipeline (degree=20)                                                                                                        ]     4015 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Pipeline degree=20]: 0.10x speedup
  [Pipeline (degree=25)                                                                                                        ]     3841 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Pipeline degree=25]: 0.11x speedup
  [Pipeline (degree=26)                                                                                                        ]     4095 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Pipeline degree=26]: 0.10x speedup
  [Pipeline (degree=30)                                                                                                        ]     3804 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Pipeline degree=30]: 0.11x speedup

  ? Producer-Consumer (System.Threading.Channels)
  [Producer-Consumer (consumers=2)                                                                                             ]      808 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Producer-Consumer degree=2]: 0.51x speedup
  [Producer-Consumer (consumers=4)                                                                                             ]     1234 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Producer-Consumer degree=4]: 0.34x speedup
  [Producer-Consumer (consumers=5)                                                                                             ]     1700 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Producer-Consumer degree=5]: 0.24x speedup
  [Producer-Consumer (consumers=6)                                                                                             ]     1599 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Producer-Consumer degree=6]: 0.26x speedup
  [Producer-Consumer (consumers=10)                                                                                            ]     2390 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Producer-Consumer degree=10]: 0.17x speedup
  [Producer-Consumer (consumers=20)                                                                                            ]     2571 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Producer-Consumer degree=20]: 0.16x speedup
  [Producer-Consumer (consumers=25)                                                                                            ]     2882 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Producer-Consumer degree=25]: 0.14x speedup
  [Producer-Consumer (consumers=26)                                                                                            ]     2694 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Producer-Consumer degree=26]: 0.15x speedup
  [Producer-Consumer (consumers=30)                                                                                            ]     2231 ms
    Transactions      : 2,000,000
    Total UAH         : 175,687,719,965.83
    Cashback UAH      : 0.00
    Final UAH         : 175,687,719,965.83
    Cashback eligible : 0
  [Producer-Consumer degree=30]: 0.19x speedup