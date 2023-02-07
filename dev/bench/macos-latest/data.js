window.BENCHMARK_DATA = {
  "lastUpdate": 1675735918550,
  "repoUrl": "https://github.com/virtuosgames/libplanet",
  "entries": {
    "Benchmark.Net Benchmark": [
      {
        "commit": {
          "author": {
            "email": "hong@minhee.org",
            "name": "Hong Minhee (洪 民憙)",
            "username": "dahlia"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "fa15924beb36a7ebe3d92052f5c20af2a235916c",
          "message": "Merge pull request #2788 from dahlia/0.48-maintenance",
          "timestamp": "2023-02-06T19:09:15+09:00",
          "tree_id": "756adedd8cd6f72fe1983dfa077c437153ef7b89",
          "url": "https://github.com/virtuosgames/libplanet/commit/fa15924beb36a7ebe3d92052f5c20af2a235916c"
        },
        "date": 1675735862801,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Libplanet.Benchmarks.BlockChain.ContainsBlock",
            "value": 144213.92708333334,
            "unit": "ns",
            "range": "± 10880.506068188663"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutFirstEmptyBlock",
            "value": 134783.23157894737,
            "unit": "ns",
            "range": "± 17116.547865718065"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutFirstBlockWithTxs",
            "value": 264414.806122449,
            "unit": "ns",
            "range": "± 27023.992876761586"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutBlockOnManyBlocks",
            "value": 243537.1914893617,
            "unit": "ns",
            "range": "± 9316.611577640319"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetOldBlockOutOfManyBlocks",
            "value": 3850989.9032258065,
            "unit": "ns",
            "range": "± 115907.2544173012"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetRecentBlockOutOfManyBlocks",
            "value": 10623641.846153846,
            "unit": "ns",
            "range": "± 69410.89071589817"
          },
          {
            "name": "Libplanet.Benchmarks.Store.TryGetNonExistentBlockHash",
            "value": 30861.478723404256,
            "unit": "ns",
            "range": "± 3922.4586183216347"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutFirstTx",
            "value": 77377.90721649484,
            "unit": "ns",
            "range": "± 11975.50372642914"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutTxOnManyTxs",
            "value": 58713.84693877551,
            "unit": "ns",
            "range": "± 9875.823703453378"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetOldTxOutOfManyTxs",
            "value": 134518.22631578948,
            "unit": "ns",
            "range": "± 19096.633977903075"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetRecentTxOutOfManyTxs",
            "value": 8373.211111111112,
            "unit": "ns",
            "range": "± 1780.8489295803604"
          },
          {
            "name": "Libplanet.Benchmarks.Store.TryGetNonExistentTxId",
            "value": 33404.29381443299,
            "unit": "ns",
            "range": "± 6621.682653629514"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockEmpty",
            "value": 5063809.302162248,
            "unit": "ns",
            "range": "± 295853.52049072087"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockOneTransactionNoAction",
            "value": 7576415.3,
            "unit": "ns",
            "range": "± 124365.0664783782"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockTenTransactionsNoAction",
            "value": 27062046,
            "unit": "ns",
            "range": "± 541753.5518055004"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockOneTransactionWithActions",
            "value": 7090143.408163265,
            "unit": "ns",
            "range": "± 521106.2737013872"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockTenTransactionsWithActions",
            "value": 32828108.5,
            "unit": "ns",
            "range": "± 561833.7585031783"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.EncodeRootModel",
            "value": 7105627.715885417,
            "unit": "ns",
            "range": "± 205601.3016510795"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.EncodeLeafModel",
            "value": 2053512.833203125,
            "unit": "ns",
            "range": "± 31303.96736024488"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.EncodeRawLeafModel",
            "value": 1316672.3856026786,
            "unit": "ns",
            "range": "± 21106.157882053736"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.DecodeRootModel",
            "value": 2759405.1141237747,
            "unit": "ns",
            "range": "± 110024.56746751764"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.DecodeLeafModel",
            "value": 774790.6385416667,
            "unit": "ns",
            "range": "± 11763.812093619486"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.DecodeRawLeafModel",
            "value": 758001.4042697483,
            "unit": "ns",
            "range": "± 25268.39074011788"
          }
        ]
      }
    ]
  }
}